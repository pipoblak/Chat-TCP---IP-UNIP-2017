using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace CHAT_TCP_IP_APS
{
    public class UserClient
    {
        public delegate void StringEventHandler(UserClient user, string text);
        public event StringEventHandler MessageReceived;

        public delegate void DisconnectEventHandler(UserClient user, string reason);
        public event DisconnectEventHandler Disconnected;

        public string nickname { get; set; }
        public long current_ping { get; set; }
        public DateTime current_connection_datetime { get; set; }
        public string connection_id { get; set; }
        public bool connection_status { get; set; }
        public string current_ip { get; set; }

        [JsonIgnore]
        public TcpClient user { get; set; }
        
        public UserClient(TcpClient client)
        {
            this.user = client;
            Initialize();
        }
        public UserClient(string nickname)
        {
            this.nickname = nickname;
        }
        public UserClient() {
        }
        public UserClient(string nickname,long current_ping,DateTime current_connection_datetime, string connection_id, bool connection_status,string current_ip) {
            this.nickname = nickname;
            this.current_connection_datetime = current_connection_datetime;
            this.current_ping = current_ping;
            this.connection_id = connection_id;
            this.connection_status = connection_status;
            this.current_ip = current_ip;
        }
        public UserClient(TcpClient client, string nickname , string connection_id)
        {
            this.user = client;
            this.nickname = nickname;
            Initialize();
        }
        private void Initialize()
        {
            connection_status = true;
            try {
                current_ip = user.Client.RemoteEndPoint.ToString();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            BeginRead();
        }

        public void connectToServer(IPAddress ip, int port) {
            user.BeginConnect(ip, port, login,new object());
        }
        public void login(object a) {
            if (user.Connected) {
                SendPacket(new Message().strMessage( this,null,"Connected",Message.CONNECTED_TYPE));
            }
            
        }

        public void logout()
        {
            
            OnDisconnected("Logout");
        }

        public void BeginRead()
        {
            if (user.Connected)
            {
                byte[] buffer = new byte[6 * 1024];
                user.GetStream().BeginRead(buffer, 0, 6 * 1024, ReceiveMessages, buffer);
            }
        }
        private void ReceiveMessages(IAsyncResult result)
        {
            if (connection_status)
            {
                int length;

                try
                {
                    length = user.GetStream().EndRead(result);
                }
                catch (Exception e)
                {
                    OnDisconnected(e.Message);
                    return;
                }

                if (length > 0)
                {
                    byte[] buffer = (byte[])result.AsyncState;
                    string text = Encoding.UTF8.GetString(buffer, 0, length);
                    OnMessageReceived(text);
                }

                BeginRead();
            }
        }
        protected void OnMessageReceived(string text)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, text);
            }
        }
        protected void OnDisconnected(string reason)
        {
            connection_status = false;
            
            if (Disconnected != null)
            {
                 Disconnected(this, reason);
            }
        }
        public void SendPacket(string packetInfo)
        {
            new Thread(() => SendPacketThread(packetInfo)).Start();
        }

        private void SendPacketThread(string packetInfo)
        {
            try
            {
                StreamWriter sw = new StreamWriter(user.GetStream());
                //jsonserializersettings jsonsettings = new jsonserializersettings
                //{
                //    nullvaluehandling = nullvaluehandling.ignore
                //};
                //string data = jsonconvert.serializeobject(packetinfo, jsonsettings);
                sw.Write(packetInfo);
                sw.Flush();
            }
            catch (Exception e)
            {

            }
        }
    }
}
