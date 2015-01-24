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
using MahApps.Metro.Controls;



namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow// : MetroWindow
    {

        private MainPanelBean mainPanel = new MainPanelBean();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlHome());
            mainPanel.getPnlHome().loadPage();
        }

        private void btnMngEvents_Click(object sender, RoutedEventArgs e)
        {
         
            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlMngEvents());

            //Al
            mainPanel.getPnlMngEvents().setData();
        }

        private void btnMngDrivers_Click(object sender, RoutedEventArgs e)
        {

            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlDriver());

            //Al
            mainPanel.getPnlDriver().DriverList_method();



        }

        private void btnAddDriverToEvent_Click(object sender, RoutedEventArgs e)
        {
            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlAddDriverToEvent());

            //Al
            mainPanel.getPnlAddDriverToEvent().setData();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlReport());

            mainPanel.getPnlReport().setDriverList();
        }

        private void btnManageTags_Click(object sender, RoutedEventArgs e)
        {
            pnlMain.Children.Clear();
            pnlMain.Children.Add(mainPanel.getPnlManageRfidNo());

            mainPanel.getPnlManageRfidNo().setData();
        }


        


    }
}
