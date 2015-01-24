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

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for PnlAddDriverToEvent.xaml
    /// </summary>
    public partial class PnlAddDriverToEvent : UserControl
    {
        DBConnectionEvents dbConnectionEvent;
        DBConnectionEventDriver dbConnectionDriver;
        //Container of all data
        List<EventsBean> eventDataList;
        // List<Events> eventDataList_original;
        Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList;
        List<RaceClass> raceClassList;

       private string session_id_selected;
       private string event_id_selected;
       private string class_id_selected;

       private List<DriverDetailsBean> selectedDriver;

        public PnlAddDriverToEvent()
        {
            InitializeComponent();
            dbConnectionEvent = new DBConnectionEvents();
            dbConnectionDriver = new DBConnectionEventDriver();
        }

        public void setData()
        {
            List<EventsBean> eventsList = dbConnectionEvent.selectEvent();
            if (eventsList == null || eventsList.Count == 0)
            {
                eventDataList = new List<EventsBean>();
                //eventDataList_original = new List<Events>();
            }
            else
            {
                eventDataList = eventsList;
                // eventDataList_original = new List<Events>(eventsList);
            }

            raceClassWithSessionList = new Dictionary<RaceClass, List<RaceSession>>();
            raceClassList = new List<RaceClass>();
            selectedDriver = new List<DriverDetailsBean>();

            eventComboBox.ItemsSource = eventDataList;

            buttonAddDriver.IsEnabled = false;
            buttonRemoveDriver.IsEnabled = false;

         
         
        }

        private void onAddDriverClick(object sender, RoutedEventArgs e)
        {
            AddDriverToEventForm adte = new AddDriverToEventForm(event_id_selected,class_id_selected ,session_id_selected);
            adte.handler += new AddDriverToEventForm.AddDriverToEventFormHandler(onAddDriver);
            adte.ShowDialog();
        }

        private void onAddDriver(object sender)
        {
            repopulateDriverList();
            System.Windows.Forms.MessageBox.Show("Racer is successfully added.");
        }

        private void onRemoveDriverClick(object sender, RoutedEventArgs e)
        {
          
            dbConnectionDriver.removeDrivers(selectedDriver);
            repopulateDriverList();
            System.Windows.Forms.MessageBox.Show("Racer/s is successfully removed.");

        }

        private void DriverListItemClickEvent(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
                selectedDriver.Remove((DriverDetailsBean)e.RemovedItems[0]);
            if (e.AddedItems.Count > 0)
                selectedDriver.Add((DriverDetailsBean)e.AddedItems[0]);
            if (registeredDriverList.Items.Count > 0)
                buttonRemoveDriver.IsEnabled = true;
        }

        private void eventComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            EventsBean events = ((sender as ComboBox).SelectedItem as EventsBean);
            if (events != null)
            {
                raceClassWithSessionList = events.EventsRaceClass;
                raceClassList = events.RaceClassLists;

                raceClassComboBox.ItemsSource = raceClassList;

                event_id_selected = events.EventId;
            }
            else
            {
                raceClassComboBox.ItemsSource = null;
            }
        }

        private void raceClassComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            /*RaceClass raceClass = ((sender as ComboBox).SelectedItem as RaceClass);
            if (raceClass != null)
            {
                List<RaceSession> raceSessionList = raceClassWithSessionList[raceClass];

                raceSessionComboBox.ItemsSource = raceSessionList;

                class_id_selected = raceClass.ClassId;
            }
            else
            {
                raceSessionComboBox.ItemsSource = null;
            }*/

            RaceClass raceClass = ((sender as ComboBox).SelectedItem as RaceClass);
            if (raceClass != null)
            {
                List<DriverDetailsBean> driverDetailsBeanList = dbConnectionDriver.getRegisteredDriverUsingClassId(raceClass.ClassId);
                registeredDriverList.ItemsSource = driverDetailsBeanList;
                class_id_selected = raceClass.ClassId;

                buttonAddDriver.IsEnabled = true;
            }
            else
            {
                buttonAddDriver.IsEnabled = false;
                buttonRemoveDriver.IsEnabled = false;
                registeredDriverList.ItemsSource = null;
            }
        }


        private void repopulateDriverList()
        {
            //List<DriverDetailsBean> driverDetailsBeanList = dbConnectionDriver.getRegisteredDriver(session_id_selected);
            List<DriverDetailsBean> driverDetailsBeanList = dbConnectionDriver.getRegisteredDriverUsingClassId(class_id_selected);
            registeredDriverList.ItemsSource = driverDetailsBeanList;
        }

        private void raceSessionComboBoxSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            RaceSession rs = ((sender as ComboBox).SelectedItem as RaceSession);
            if (rs != null)
            {
                List<DriverDetailsBean> driverDetailsBeanList = dbConnectionDriver.getRegisteredDriver(rs.SessionId);
                registeredDriverList.ItemsSource = driverDetailsBeanList;
                session_id_selected = rs.SessionId;

                buttonAddDriver.IsEnabled = true;
               
            }
            else
            {
                buttonAddDriver.IsEnabled = false;
                buttonRemoveDriver.IsEnabled = false;
                registeredDriverList.ItemsSource = null;
            }
           
        }
        

        
    }

 


}
