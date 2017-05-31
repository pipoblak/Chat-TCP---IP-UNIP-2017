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
using System.Diagnostics;
using System.Windows.Media;

namespace CHAT_TCP_IP_APS
{
    public class UserClient
    {
        //Handler para Mensagem Recebida pelo usuário
        public delegate void StringEventHandler(UserClient user, string text);
        public event StringEventHandler MessageReceived;

        //Handler para quando o usuário for desconectado.
        public delegate void DisconnectEventHandler(UserClient user, string reason);
        public event DisconnectEventHandler Disconnected;

        //Propiedades do usuário
        public string nickname { get; set; }
        public long current_ping { get; set; }
        public DateTime current_connection_datetime { get; set; }
        public string connection_id { get; set; }
        public bool connection_status { get; set; }
        public string current_ip { get; set; }
        public Color color { get; set; }

        //Stopwatch para medir ping
        public Stopwatch pingTimer;
        [JsonIgnore]
        public TcpClient user { get; set; }
        
        //Métodos construtores
        public UserClient(TcpClient client)
        {
            this.user = client;
            Initialize();
        }
        public UserClient(string nickname)
        {
            this.nickname = nickname;
        }
        public UserClient(string nickname, Color color)
        {
            this.nickname = nickname;
            this.color = color;
        }
        public UserClient(TcpClient client,string nickname,Color color)
        {
            this.user = client;
            this.color = color;
            this.nickname = nickname;
            Initialize();
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

        //Metodo de Inicialização do Cliente
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

        //Método de envio de ping para o server
        public void sendPing() {
            SendPacket(new Message().strMessage(null, null, "Ping", Message.PING_TYPE));
            pingTimer = Stopwatch.StartNew();
        }

        //Retorna o tempo passado desde o ultimo ping em millis
        public long getPong() {
            return pingTimer.ElapsedMilliseconds;
        }

        //conecta com o servidor TCP-IP
        public void connectToServer(IPAddress ip, int port) {
            user.Connect(ip, port);
            login();
        }

        //Metodo que é executado após conectar, enviando os dados do usuário para o server.
        public void login() {
            if (user.Connected) {
                SendPacket(new Message().strMessage( this,null,"Connected",Message.CONNECTED_TYPE));
                BeginRead();
            }
            
        }

        //Desconecta o usuário
        public void logout()
        {
            
            OnDisconnected("");
        }

        //Expulsa um usuário
        public void kick(string reason)
        {

            OnDisconnected(reason);
        }

        //Procura por dados na Stream do server
        public void BeginRead()
        {
            try
            {
                byte[] buffer = new byte[1024];
                user.GetStream().BeginRead(buffer, 0, 1024, ReceiveMessages, buffer);
            }
            catch (Exception e)
            {

            }
        }

        //Assynctask apos receber mensagem
        private void ReceiveMessages(IAsyncResult result)
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

        //Ação quando recebe uma mensagem
        protected void OnMessageReceived(string text)
        {
            if (MessageReceived != null)
            {
                MessageReceived(this, text);
            }
        }

        //Ação quando desconecta
        protected void OnDisconnected(string reason)
        {
            connection_status = false;
            
            if (Disconnected != null)
            {
                 Disconnected(this, reason);
            }
        }
        //Envio de Pacote com thread.
        public void SendPacket(string packetInfo)
        {
            new Thread(() => SendPacketThread(packetInfo)).Start();
        }

        private void SendPacketThread(string packetInfo)
        {
            try
            {
                StreamWriter sw = new StreamWriter(user.GetStream());
                sw.Write(packetInfo);
                sw.Flush();
            }
            catch (Exception e)
            {

            }

        }
    }
}
