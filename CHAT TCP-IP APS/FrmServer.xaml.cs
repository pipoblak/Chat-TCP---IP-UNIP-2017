using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for FrmServer.xaml
    /// </summary>
    public partial class FrmServer : Window
    {
        Server server;

        public FrmServer()
        {
            server = new Server(56863);
            server.ConsoleOutput += server_ConsoleOutput;
            server.UserConnected += server_UserConnected;
            server.UserDisconnected += server_UserDisconnected;
            server.PingRefresh += server_PingRefresh;
            InitializeComponent();
            serverConsole.IsReadOnly = true;
            server.start();
            this.lvConnectedUsers.ItemsSource = server.users;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            server.stop();
            this.Close();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            String clientId= (((TextBlock) ((Canvas)sender).Children[3]).Text);
            MessageBox.Show(clientId);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void server_ConsoleOutput(string message)
        {
            this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,new Action(() => this.serverConsole.AppendText(message+"\n")));
            this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.serverConsole.ScrollToEnd()));
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }

        public void server_UserConnected(List<UserClient> users) {
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }

        public void server_UserDisconnected(List<UserClient> users)
        {
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }

        public void server_PingRefresh(String refresh)
        {
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            server.SendToAll(new Message().strMessage(new UserClient("SERVER",Colors.Gold), null,"SERVER : "+ txtMensagem.Text +"\n", Message.SIMPLE_MESSAGE_TYPE));
            server.writeConsole("Broadcast: " + txtMensagem.Text);
            txtMensagem.Text = "";
        }
    }
}
