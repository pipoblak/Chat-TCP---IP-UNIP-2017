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
            InitializeComponent();
            
            server.start();
            this.lvConnectedUsers.ItemsSource = server.users;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            String clientId= (((TextBlock) ((Canvas)sender).Children[3]).Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void server_ConsoleOutput(string message)
        {
            this.serverConsole.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,new Action(() => this.serverConsole.AppendText(message+"\n")));
        }

        public void server_UserConnected(List<UserClient> users) {
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }

        public void server_UserDisconnected(List<UserClient> users)
        {
            this.lvConnectedUsers.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => this.lvConnectedUsers.Items.Refresh()));
        }
    }
}
