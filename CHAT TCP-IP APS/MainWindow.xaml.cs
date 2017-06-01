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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;


namespace CHAT_TCP_IP_APS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Windows.Forms.NotifyIcon notifyIcon  = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();
            Icon m_ico = System.Drawing.Icon.FromHandle((Properties.Resources.aps.GetHicon()));
            notifyIcon.Icon = m_ico; 
            notifyIcon.Visible = true;
            notifyIcon.Click += NotifyIcon_Click;

        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnServidor_Click(object sender, RoutedEventArgs e)
        {
            try {
                FrmServer frmServer = new FrmServer();
                frmServer.Show();
                notifyIcon.ShowBalloonTip(500,"Minimizado para Barra de Tarefas","Se desejar ver as opções clique no Icone na barra de tarefas",System.Windows.Forms.ToolTipIcon.Info);
                this.Hide();
            } catch  { }
            
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            UserForm frmClient = new UserForm();
            frmClient.Show();
            notifyIcon.ShowBalloonTip(500, "Minimizado para Barra de Tarefas", "Se desejar ver as opções clique no Icone na barra de tarefas", System.Windows.Forms.ToolTipIcon.Info);
            this.Hide();
        }
    }
}
