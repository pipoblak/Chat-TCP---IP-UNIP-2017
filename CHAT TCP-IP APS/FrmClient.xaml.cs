using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CHAT_TCP_IP_APS
{
    /// <summary>
    /// Interaction logic for FrmClient.xaml
    /// </summary>
    public partial class FrmClient : Window
    {
        UserClient client;
        String messageAssist = "";
        List<UserClient> users = new List<UserClient>();
        public FrmClient()
        {
            InitializeComponent();
            lvConnectedUsers.ItemsSource = users;
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            client.SendPacket((new Message()).strMessage(client, null, "Logout", Message.DISCONNECTED_TYPE));
            client.logout();
           
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           

        }
        public void Listen() {
            if (client.user.Connected)
                client.BeginRead();
            else {
                this.btnEnviar.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.btnEnviar.IsEnabled=false));
                this.txtMensagem.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.txtMensagem.IsEnabled = false));
            }
        }
        public void messageRecived(UserClient user, string text) {
            try {
                messageAssist += text;
                Message message = Message.getDeserializedMessage(messageAssist);
                switch (message.msgType)
                {
                    case 4:
                        users = JsonConvert.DeserializeObject<List<UserClient>>(message.message);

                        this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.ItemsSource = users));
                        this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
                        break;
                    case 1:
                        this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.serverConsole.AppendText(message.message)));
                        break;
                }
                
                messageAssist = "";
            } catch (Exception ex) {
                
            }
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new UserClient(new TcpClient(), "champson",null);
                client.MessageReceived += messageRecived;
                client.Disconnected += disconnect;
                client.connectToServer(IPAddress.Parse("127.0.0.1"), 56863);
                Thread listenerThread = new Thread(Listen);
                listenerThread.IsBackground = true;
                listenerThread.Start();
                txtMensagem.Focus();
            } catch (Exception ex) {
                btnEnviar.IsEnabled = false;
                txtMensagem.IsEnabled = false;
            }
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            
            if (client.connection_status = true) {
                client.SendPacket((new Message()).strMessage(client,null,txtMensagem.Text,Message.SIMPLE_MESSAGE_TYPE));
                txtMensagem.Text = "";

            }
           
        }
        public void disconnect(UserClient user ,string reason) {
            
            this.Close();

        }
    }
}
