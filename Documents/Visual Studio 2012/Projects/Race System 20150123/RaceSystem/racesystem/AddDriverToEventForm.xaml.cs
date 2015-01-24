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

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for AddDriverToEventForm.xaml
    /// </summary>
    public partial class AddDriverToEventForm : Window
    {
        public delegate void AddDriverToEventFormHandler (object sender);

        public AddDriverToEventFormHandler handler;

        private DBConnectionEventDriver dbConnection;


        private string Driver_Id;
        private string Session_id;
        private string Class_Id;
        private string Event_Id;
        private string Rfid_No;


        public AddDriverToEventForm()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Add.IsEnabled = false;
            vehicleModel.IsEnabled = false;
            rfidComboBox.IsEnabled = false;
        }
        public AddDriverToEventForm(string event_id, string class_id, string session_id )
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Add.IsEnabled = false;
            vehicleModel.IsEnabled = false;
            rfidComboBox.IsEnabled = false;
            this.Session_id = session_id;
            this.Class_Id = class_id;
            this.Event_Id = event_id;
            getDriversList();
           
        }

        public AddDriverToEventForm(string event_id, string class_id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Add.IsEnabled = false;
            vehicleModel.IsEnabled = false;
            rfidComboBox.IsEnabled = false;
            this.Class_Id = class_id;
            this.Event_Id = event_id;
            getDriversList();


        }

        private void onCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onAddClick(object sender, RoutedEventArgs e)
        {

            if (Rfid_No == null || Rfid_No.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Please choose a RFID Number for the racer.");
                return;
            }
            if (vehicleModel.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Please Input Vehicle Model");
                return;
            }


            //registerDriver();
            registerDriverUsingClassId();
            this.Close();
            handler(this);
        }


        public void onDriverSelected(object sender, SelectionChangedEventArgs args)
        {
            DriverDetailsBean ddb = (DriverDetailsBean)driverList.SelectedItem;
            if (ddb != null)
            {
                driverName.Text = ddb.Name;
                teamId.Text = ddb.Team_id;
                vehicleModel.Text = ddb.Vehicle_model;
                Driver_Id = ddb.Driver_Id;

                if (!Add.IsEnabled)
                    Add.IsEnabled = true;

                vehicleModel.IsEnabled = true;
                rfidComboBox.IsEnabled = true; 

            }
            else
            {
                vehicleModel.IsEnabled = false;
                rfidComboBox.IsEnabled = false;
                Add.IsEnabled = false;

                driverName.Text = "";
                teamId.Text = "";
                vehicleModel.Text = "";
                rfidComboBox.Text = "";
            }
            
        }

        private void getDriversList()
        {
           dbConnection = new DBConnectionEventDriver();
           /* List<DriverDetailsBean> list =  dbConnection.getNotRegisteredDrivers(Session_id);
            driverList.ItemsSource = list;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(driverList.ItemsSource);
            view.Filter = UserFilter;

            getRfidList();*/

            List<DriverDetailsBean> list = dbConnection.getNotRegisteredDriversUsingClassId(Class_Id);
            driverList.ItemsSource = list;


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(driverList.ItemsSource);
            view.Filter = UserFilter;

            getRfidList();
            
        }


        private void getRfidList()
        {
            List<RfidBean> list = dbConnection.getAllRfidNotRegisteredList();
            rfidComboBox.ItemsSource = list;
        }

        private void registerDriver()
        {
           
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("event_id",Event_Id);
            map.Add("session_id",Session_id);
            map.Add("driver_id", Driver_Id);
            map.Add("rfid_no", Rfid_No);
            map.Add("class_id", Class_Id);
            dbConnection.registerDriver(map);
        }

        private void registerDriverUsingClassId()
        {

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("event_id", Event_Id);
            map.Add("driver_id", Driver_Id);
            map.Add("rfid_no", Rfid_No);
            map.Add("class_id", Class_Id);
            map.Add("vehicle_id", vehicleModel.Text);
            dbConnection.registerDriverUsingClassId(map);
        }

          private void rfidComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
          {
              Rfid_No = Convert.ToString(((sender as ComboBox).SelectedItem as RfidBean).Rfid_No);
          }


        //for filter
          private void Filter_Changed(object sender, TextChangedEventArgs e)
          {
              CollectionViewSource.GetDefaultView(driverList.ItemsSource).Refresh();
          }

          private bool UserFilter(object item)
          {
              if (String.IsNullOrEmpty(txtFilter.Text))
                  return true;
              else
                  return ((item as DriverDetailsBean).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
          }


      
    }
}
