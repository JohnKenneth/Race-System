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
using MahApps.Metro.Controls;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow// : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("RS" + DateTime.Now.ToString("yyyyMMdd") + "  " + tfPassword.Password);
            if (tfUserName.Text == "admin" && (tfPassword.Password == "RS" + DateTime.Now.ToString("yyyyMMdd")))
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
                MessageBox.Show("Username/Password is Invalid", "Validation", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
