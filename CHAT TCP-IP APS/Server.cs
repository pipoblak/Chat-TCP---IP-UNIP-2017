using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public List<UserClient> users { get; set; }
        public string serverOutput { get; set; }
        public int port { get; set; }
        public TcpListener listener;

        public bool isServerOnline;
        JsonSerializerSettings jsonsettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
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
           
            

        }
        public void stop() {
            
            isServerOnline = false;
            listener.Stop();
            writeConsole("Server Fechado.");
        }

        public void Listen() {
            while (isServerOnline) {
                TcpClient client = listener.AcceptTcpClient();
                UserClient userClient = new UserClient(client);
                userClient.MessageReceived += messageRecived;
                userClient.Disconnected += userDisconnect;
                writeConsole(string.Format("Cliente Conectado: {0}", userClient.current_ip));
                
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
                    users.Add(user);
                    UserConnected(users);
                    SendToAll(new Message().strMessage(null,null, JsonConvert.SerializeObject(users.ToArray(), jsonsettings) , Message.REFRESH_TYPE));
                    break;

                case 1:
                    writeConsole(message.from.nickname + " : " + message.message + "\n");
                    SendToAll(new Message().strMessage(user, null, message.from.nickname + " : " + message.message + "\n", Message.SIMPLE_MESSAGE_TYPE));
                    
                    break;
                case 3:
                    user.logout();
                    writeConsole(message.from.nickname + " Saiu");
                    break;


            }
            //writeConsole(message.message);
            //SendToAll(text);
        }
        public void userDisconnect(UserClient user, string text)
        {
            users.Remove(user);
            UserDisconnected(users);
            SendToAll(new Message().strMessage(null, null, JsonConvert.SerializeObject(users.ToArray(), jsonsettings), Message.REFRESH_TYPE));
        }
        public void SendToAll(string packetInfo)
        {
            foreach (UserClient client in users)
            {
                client.SendPacket(packetInfo);
            }
        }

    }
}
