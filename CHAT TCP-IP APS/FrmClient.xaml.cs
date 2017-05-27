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
        Thread pingerThread;
        bool listLoaded = false;
        string ipAddress;
        public FrmClient()
        {
            InitializeComponent();
            serverConsole.IsReadOnly = true;
            
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(client.user.Connected)
            client.SendPacket((new Message()).strMessage(client, null, "Logout", Message.DISCONNECTED_TYPE));
            client.logout();
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           

        }
        public void Listen() {
            try {
                if (client.user.Connected)
                {

                }
                else {
                    this.btnEnviar.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.btnEnviar.IsEnabled = false));
                    this.txtMensagem.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.txtMensagem.IsEnabled = false));
                }
            } catch (Exception e ) { MessageBox.Show(e.Message); }
            client.BeginRead();
      
            
        }
        public void messageRecived(UserClient user, string text) {
           try
            {
                try {
                    messageAssist += text;
                    Message message = Message.getDeserializedMessage(messageAssist);
                    switch (message.msgType)
                    {
                        case 0:
                            pingerThread.Start();
                            user.connection_id = message.message;
                            break;
                        case 1:
                            this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => textWithColor(this.serverConsole, message.message, message.from.color)));
                            this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.serverConsole.ScrollToEnd()));
                            break;
                        case 3:
                            user.kick(message.message);
                        break;
                        case 4:
                            users = JsonConvert.DeserializeObject<List<UserClient>>(message.message);
                            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.ItemsSource = users));
                            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
                            break;
                            
                        case 5:
                            user.current_ping = user.getPong();
                            users.Find(UserClient => UserClient.connection_id == user.connection_id).current_ping = user.current_ping;
                            client.SendPacket((new Message()).strMessage(null, null, JsonConvert.SerializeObject(user), Message.REFRESH_PING_TYPE));
                            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
                            break;
                        case 6:
                            UserClient userRefresh = JsonConvert.DeserializeObject<UserClient>(message.message);
                            if (userRefresh.connection_id != user.connection_id)
                            {
                                users.Find(UserClient => UserClient.connection_id == userRefresh.connection_id).current_ping = userRefresh.current_ping;
                                this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
                            }
                            break;
                    }

                    messageAssist = "";
                } catch (Exception ee) { }
                    
                
            }
            catch (Exception ex)
            {

            }
        
            
        }

        public void Show(UserClient client,String ip) {
            this.client = client;
            ipAddress = ip;
            this.Show();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                client.MessageReceived += messageRecived;
                client.Disconnected += disconnect;
                Thread listenerThread = new Thread(Listen);
                listenerThread.IsBackground = true;
                listenerThread.Start();
                client.connectToServer(IPAddress.Parse(ipAddress), 56863);
                pingerThread = new Thread(Ping);
                pingerThread.IsBackground = true;
                txtMensagem.Focus();
                lvConnectedUsers.ItemsSource = users;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                btnEnviar.IsEnabled = false;
                txtMensagem.IsEnabled = false;
            }
        }

        //CALLBACK Thread de Ping - 1000 Millis de intervalo de ping request
        public void Ping() {
            while (client.user.Connected) {
                if (!listLoaded)
                {
                    this.btnEnviar.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.btnEnviar.IsEnabled = true));
                    this.txtMensagem.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.txtMensagem.IsEnabled = true));
                    client.SendPacket(new Message().strMessage(null, null, "Refresh", Message.REFRESH_TYPE));
                    listLoaded = true;
                }
                else
                    client.sendPing();

                this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
                Thread.Sleep(5000);
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
            if (reason != "")
                MessageBox.Show("Desconectando... Razão: " + reason);
            
        }
        public static void textWithColor( RichTextBox serverConsole, string text, Color color)
        {
            SolidColorBrush bc = new SolidColorBrush(color);
            TextRange tr = new TextRange(serverConsole.Document.ContentEnd, serverConsole.Document.ContentEnd);
            tr.Text = text;
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty,bc);
            }
            catch (FormatException) { }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (client != null)
            {
                if (comboBox.SelectedIndex == 0)
                    client.color = Colors.Black;
                else if (comboBox.SelectedIndex == 1)
                    client.color = Colors.Red;
                else if (comboBox.SelectedIndex == 2)
                    client.color = Colors.Green;
                else if (comboBox.SelectedIndex == 3)
                    client.color = Colors.Blue;
                else if (comboBox.SelectedIndex == 4)
                    client.color = Colors.Yellow;

            }

        }
    }
}
