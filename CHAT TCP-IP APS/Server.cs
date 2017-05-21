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
        public event Action<string> ConsoleOutput;
        public event Action<List<UserClient>> UserConnected;
        public event Action<List<UserClient>> UserDisconnected;
        public event Action<string> PingRefresh;
        
        public List<UserClient> users { get; set; }
        public string serverOutput { get; set; }
        public int port { get; set; }
        public TcpListener listener;
        public List<string> MessagesQueue = new List<string>();
        public bool isServerOnline;
        public void writeConsole(string message ) { ConsoleOutput(message); }
        public Server(int port) {
            this.port = port;
        }
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



        }
        public void stop() {
            
            isServerOnline = false;
            listener.Stop();
            writeConsole("Server Fechado.");
        }

        public void Listen() {
            while (isServerOnline) {
                try {
                    TcpClient client = listener.AcceptTcpClient();
                    UserClient userClient = new UserClient(client);
                    userClient.MessageReceived += messageRecived;
                    userClient.Disconnected += userDisconnect;
                    writeConsole(string.Format("Cliente Conectado: {0}", userClient.current_ip));
                } catch (Exception e) {
                }
                
                
            }
            
        }
        public void messageRecived(UserClient user, string text) {
            Message message = Message.getDeserializedMessage(text);
            switch (message.msgType) {
                case 0:
                    user.nickname = message.from.nickname;
                    user.current_connection_datetime = DateTime.Now;
                    user.current_ping = 0;
                    user.connection_id = Guid.NewGuid().ToString("N");
                    if (users.FindAll(UserClient => UserClient.nickname.Equals(user.nickname) == true).Count > 0) { 
                        user.SendPacket(new Message().strMessage(null, null, "Nome já utilizado", Message.DISCONNECTED_TYPE));
                        user.logout();
                        writeConsole(message.from.nickname + " repetido KICKADO");
                       }
                    else {
                        users.Add(user);
                        UserConnected(users);
                        user.SendPacket(new Message().strMessage(null, null, "" + user.connection_id, Message.CONNECTED_TYPE));
                    }
                    
                  break;

                case 1:
                    writeConsole(message.from.nickname + " : " + message.message);
                    SendToAll(new Message().strMessage(message.from, null, message.from.nickname + " : " + message.message + "\n", Message.SIMPLE_MESSAGE_TYPE));
                    
                    break;
                case 3:
                    user.logout();
                    writeConsole(message.from.nickname + " Saiu");
                    SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
                    break;
                case 4:
                    SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
                    break;
                case 5:
                    user.SendPacket(new Message().strMessage(null, null, "pong", Message.PING_TYPE));
                    break;
                case 6:
                    user.current_ping = JsonConvert.DeserializeObject<UserClient>(message.message).current_ping;
                    SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(user), Message.REFRESH_PING_TYPE));
                    PingRefresh("Refresh");
                    break;
            }
            //writeConsole(message.message);
            //SendToAll(text);
        }
        public void userDisconnect(UserClient user, string text)
        {
            users.Remove(user);
            UserDisconnected(users);
            SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray()), Message.REFRESH_TYPE));
        }
        public void SendToAll(string packetInfo)
        {
            MessagesQueue.Add(packetInfo);
        }

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
