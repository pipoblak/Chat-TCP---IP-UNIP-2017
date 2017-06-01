using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CHAT_TCP_IP_APS
{
    class Server
    {
        //Ações que são chamadas pelo server de acordo com o que está acontecendo
        public event Action<string> ConsoleOutput;
        public event Action<List<UserClient>> UserConnected;
        public event Action<List<UserClient>> UserDisconnected;
        public event Action<string> PingRefresh;
        
        //Lista de Usuários que estão conectados
        public List<UserClient> users { get; set; }

        //Porta do Servidor
        public int port { get; set; }

        //Listener do servidor
        public TcpListener listener;

        //Lista de Mensagens que serão enviadas de forma assincrona  para TODOS usuários.
        public List<string> MessagesQueue = new List<string>();

        public bool isServerOnline;

        //Método que dispara a ação de ConsoleOutput
        public void writeConsole(string message ) { ConsoleOutput(message); }

        //Método Construtor que instancia apenas a porta do servidor
        public Server(int port) {
            this.port = port;
        }

        //Metodo que começa o Server e os threads que são necessários
        public void start() {
            users = new List<UserClient>();
            isServerOnline = true;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            writeConsole("TCP Listener Iniciado");
            Thread listenerThread = new Thread(Listen);
            listenerThread.IsBackground = true;
            listenerThread.Start();
            Thread messagesQueueAll = new Thread(messagesToSendAll);
            messagesQueueAll.IsBackground = true;
            messagesQueueAll.Start();
            Thread pingRefreshThread = new Thread(sendListPing);
            pingRefreshThread.IsBackground = true;
            pingRefreshThread.Start();
        }

        //Thread que manda a cada 5000 segundos a lista de usuários conectados com o PING atualizado para todos usuários conectados.
        public void sendListPing() {
            while (isServerOnline) {
                Thread.Sleep(5000);
                SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
            }
            
        }

        //Para o servidor
        public void stop() {
            isServerOnline = false;
            listener.Stop();
            writeConsole("Server Fechado.");
        }

        //Método de Escuta do Servidor.
        public void Listen() {
            while (isServerOnline) {
                try {
                    TcpClient client = listener.AcceptTcpClient();
                    UserClient userClient = new UserClient(client);
                    userClient.MessageReceived += messageRecived;
                    userClient.Disconnected += userDisconnect;
                    userClient.SendPacket(new Message().strMessage(null, null, "" + userClient.connection_id, Message.CONNECTED_TYPE));
                    writeConsole(string.Format("Cliente Conectado: {0}", userClient.current_ip));
                } catch (Exception e) {
                }
                
                
            }
            
        }

        //Método disparado quando uma mensagem é recebida do usuário.
        public void messageRecived(UserClient user, string text) {
            //Instancia um objeto Mensagem, que irá deserializar um texto JSON em um objeto Mensagem
            Message message = Message.getDeserializedMessage(text);
            switch (message.msgType) {
                //Caso o Tipo da Mensagem Seja 0 ou seja Tipo Conectado irá atribuir os dados do usuário e verificará se já há um usuário com os dados dele.
                case 0:
                    user.nickname = message.from.nickname;
                    user.current_connection_datetime = DateTime.Now;
                    user.current_ping = 0;
                    user.connection_id = Guid.NewGuid().ToString("N");
                    if (users.FindAll(UserClient => UserClient.nickname.Equals(user.nickname) == true).Count > 0 || user.nickname.Equals("SERVER") || user.nickname.Equals("")) {
                        user.SendPacket(new Message().strMessage(null, null, "Nome já utilizado ou inválido.", Message.DISCONNECTED_TYPE));
                        user.logout();
                        writeConsole(message.from.nickname + " repetido KICKADO");
                    }
                    else {
                        users.Add(user);
                        UserConnected(users);
                        user.SendPacket(new Message().strMessage(null, null, "" + user.connection_id, Message.CONNECTED_TYPE));
                        writeConsole(message.from.nickname + " entrou");
                    }
                    
                  break;
                //Caso seja um tipo de Mensagem Simples irá redistribuir a mensagem recebida para todos usuários.
                case 1:
                    writeConsole(message.from.nickname + " : " + message.message);
                    SendToAll(new Message().strMessage(message.from, null, message.from.nickname + " : " + message.message + "\n", Message.SIMPLE_MESSAGE_TYPE));
                    break;
                //Caso seja um tipo Desconectado irá redistribuir que o usuário foi desconectado para todos usuários.
                case 3:
                    user.logout();
                    writeConsole(message.from.nickname + " Saiu");
                    SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
                    break;
                //Caso a mensagem seja do Tipo Refresh ( Que pede a lista mais recente de usuários)
                case 4:
                    SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
                    break;
                //Caso o server receba uma mensagem do tipo Ping
                case 5:
                    user.SendPacket(new Message().strMessage(null, null, "pong", Message.PING_TYPE));
                    break;
                //Caso receba uma requisição de PING Refresh (atualizar o ping) dispara a ação para a view
                case 6:
                    try { users.Where(UserClient => user.connection_id.Equals(user.connection_id)).First().current_ping = message.from.current_ping; }
                    catch  {
                    }
                    
                    PingRefresh("Refresh");
                    break;
            }
        }

        //Ação quando um usuário desconecta
        public void userDisconnect(UserClient user, string text)
        {
            users.Remove(user);
            UserDisconnected(users);
            writeConsole(user.nickname + " Saiu");
            SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
        }

        //Evento que adiciona mensagems à lista de mensagems a serem enviadas pra todos usuários.
        public void SendToAll(string packetInfo)
        {
            MessagesQueue.Add(packetInfo);
        }

        //Executa uma verificação para ver se há mensagens à serem enviadas e as envia.
        public void messagesToSendAll() {
            while (isServerOnline) {
                for( int i=0; i<MessagesQueue.Count; i++) {
                    for(int j=0;j < users.Count; j++) { 
                        users[j].SendPacket(MessagesQueue[i]);
                    }
                    MessagesQueue.Remove(MessagesQueue[i]);
                }
            }
        
        }
        
    }
}
