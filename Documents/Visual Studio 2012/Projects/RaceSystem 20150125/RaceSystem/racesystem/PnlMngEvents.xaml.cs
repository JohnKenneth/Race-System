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
using System.Data.SqlClient;
using System.Globalization;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for PnlMngEvents.xaml
    /// </summary>
    /// 


    public partial class PnlMngEvents : UserControl
    {
        public Label label;
        List<RaceClass> list_raceClass;
        List<RaceClass> selectedRaceClass = new List<RaceClass>();
        List<RaceSession> selectedRaceSession = new List<RaceSession>();
        List<EventsBean> selectedEvent;
        DBConnectionEvents dbConnection;





        //Container of all data
        List<EventsBean> eventDataList;
        // List<Events> eventDataList_original;
        Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList;
        int selected_event_id;




        public PnlMngEvents()
        {
            InitializeComponent();
            dbConnection = new DBConnectionEvents();

        }

        private void Race_Add_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBxValidation())
                return;

            RaceClassForm rcf = new RaceClassForm();

            rcf.RaceUpdated += new RaceClassForm.RaceUpdateHandler(addRaceClassInfo);
            rcf.Title = "Add " + rcf.Title;
            rcf.ShowDialog();


        }
        /// <summary>
        /// Check Event Name and Even Place Fields
        /// </summary>
        /// <returns></returns>
        public Boolean TxtBxValidation()
        {
            if (string.IsNullOrEmpty(EventName.Text.Trim()))
            {
                MessageBox.Show("Event Name Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(EventPlace.Text.Trim()))
            {
                MessageBox.Show("EventPlace Field is Empty!");
                return true;
            }
            return false;
        }

        private void Race_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBxValidation())
                return;

            if (Race_List.SelectedIndex != -1)
            {
                RaceClassForm rcf = new RaceClassForm();
                RaceClass raceClass = getListOfRaceClass().ElementAt(Race_List.SelectedIndex);

                rcf.RaceUpdated += new RaceClassForm.RaceUpdateHandler(editRaceClassInfo);

                rcf.Title = "Edit " + rcf.Title;
                rcf.setDefault(raceClass.Name, raceClass.Description);
                rcf.ShowDialog();
            }
        }

        private void Race_Delete_Click(object sender, RoutedEventArgs e)
        {

            /* if (Race_List.SelectedIndex != -1)
             {
                 int i = Race_List.SelectedIndex;
                 list_raceClass.RemoveAt(Race_List.SelectedIndex);
                 for(int x = i; x < list_raceClass.Count ; x++)
                 {
                     RaceClass rc = list_raceClass.ElementAt(x);
                     rc.No = x + 1;
                 }

                 Race_List.ItemsSource = null;
                 Race_List.ItemsSource = list_raceClass;


                 //Data list
                 raceClassWithSessionList.Remove(raceClass);
                 Race_Session_List.ItemsSource = null;

             }*/

            if (selectedRaceClass.Count != 0)
            {
                // List<RaceSession> dummyList = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];




                foreach (RaceClass rs in selectedRaceClass)
                {
                    raceClassWithSessionList.Remove(rs);
                    list_raceClass.Remove(rs);
                }

                /*int x = 0;
                foreach (RaceClass rc in raceClassWithSessionList.Keys)
                {
                    rc.No = x + 1;
                    x++;
                }*/

                /* int x = 0;
                 foreach (RaceClass rc in list_raceClass)
                 {
                     rc.No = x + 1;
                     x++;
                 }*/

                selectedRaceClass.Clear();
                Race_List.ItemsSource = null;
                Race_List.ItemsSource = getListOfRaceClass();

                Race_Session_List.ItemsSource = null;
                RaceS_Add.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;
            }

        }

        private void RaceS_Add_Click(object sender, RoutedEventArgs e)
        {


            RaceSessionForm rsf = new RaceSessionForm();
            rsf.RaceUpdated += new RaceSessionForm.RaceUpdateHandler(addRaceSessionInfo);
            rsf.Title = "Add " + rsf.Title;
            rsf.ShowDialog();


        }

        private void RaceS_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Race_Session_List.SelectedIndex != -1)
            {
                RaceSessionForm rsf = new RaceSessionForm();
                List<RaceSession> rs = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];
                RaceSession raceSession = rs.ElementAt(Race_Session_List.SelectedIndex);

                rsf.RaceUpdated += new RaceSessionForm.RaceUpdateHandler(editRaceSessionInfo);
                rsf.Title = "Edit " + rsf.Title;
                rsf.setDefault(raceSession.Name, raceSession.Type, raceSession.Date, raceSession.Distance, raceSession.LapNumber, raceSession.Time, raceSession.SchedTime);
                rsf.ShowDialog();

            }



        }

        private void RaceS_Delete_Click(object sender, RoutedEventArgs e)
        {

            if (selectedRaceSession.Count != 0)
            {
                List<RaceSession> dummyList = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];
                foreach (RaceSession rs in selectedRaceSession)
                {
                    dummyList.Remove(rs);
                }

                selectedRaceSession.Clear();

                Race_Session_List.ItemsSource = null;
                Race_Session_List.ItemsSource = dummyList;

                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;


            }



        }

        private void Save_Event_Click(object sender, RoutedEventArgs e)
        {
            string eventName = EventName.Text;
            string eventPlace = EventPlace.Text;
            if (selectedEvent.Count() == 0)
            {
                if (eventName.Equals("") || eventPlace.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Event Name or Event Place must not be empty.");
                }
                else
                {
                    dbConnection.insertEvent(eventName, eventPlace, raceClassWithSessionList);
                    setData();
                    System.Windows.Forms.MessageBox.Show("Event is successfully saved.");
                }
            }
            else
            {
                if (eventName.Equals("") || eventPlace.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Event Name or Event Place must not be empty.");
                }
                else
                {
                    /*dbConnection.deleteEvent(selectedEvent);
                    dbConnection.insertEvent(eventName, eventPlace, raceClassWithSessionList);*/
                    dbConnection.updateEvent(eventName, eventPlace, selectedEvent.ElementAt(0).EventId, raceClassWithSessionList);
                    setData();
                    System.Windows.Forms.MessageBox.Show("Event is successfully saved.");
                }
            }





        }



        private void Delete_Event_Click(object sender, RoutedEventArgs e)
        {

            dbConnection.deleteEvent(selectedEvent);
            setData();

            System.Windows.Forms.MessageBox.Show("Event is successfully removed.");

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            EventName.Text = "";
            EventPlace.Text = "";

            Race_Session_List.ItemsSource = null;
            Race_List.ItemsSource = null;

            selectedEvent = new List<EventsBean>();
            raceClassWithSessionList = new Dictionary<RaceClass, List<RaceSession>>();

            list_raceClass = new List<RaceClass>();

            eventListView.ItemsSource = null;
            eventListView.ItemsSource = eventDataList;

            Delete_Event.IsEnabled = false;


            RaceS_Add.IsEnabled = false;
            RaceS_Edit.IsEnabled = false;
            RaceS_Delete.IsEnabled = false;


            //Race_Add.IsEnabled = false;
            Race_Edit.IsEnabled = false;
            Race_Delete.IsEnabled = false;






        }



        //
        public void setData()//the parameter of this should be the list of events Map<event,array<details>>
        {

            List<EventsBean> eventsList = dbConnection.selectEvent();
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



            selectedEvent = new List<EventsBean>();
            raceClassWithSessionList = new Dictionary<RaceClass, List<RaceSession>>();

            list_raceClass = new List<RaceClass>();


            RaceS_Add.IsEnabled = false;
            RaceS_Edit.IsEnabled = false;
            RaceS_Delete.IsEnabled = false;


            //Race_Add.IsEnabled = false;
            Race_Edit.IsEnabled = false;
            Race_Delete.IsEnabled = false;


            selectedEvent.Clear();
            selectedRaceClass.Clear();
            selectedRaceSession.Clear();

            Race_List.ItemsSource = null;
            Race_Session_List.ItemsSource = null;
            eventListView.ItemsSource = eventDataList;


            Delete_Event.IsEnabled = false;

            EventName.Text = "";
            EventPlace.Text = "";

        }


        private void RaceClassItemClickEvent(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
                selectedRaceClass.Remove((RaceClass)e.RemovedItems[0]);
            if (e.AddedItems.Count > 0)
                selectedRaceClass.Add((RaceClass)e.AddedItems[0]);

            Race_Session_List.ItemsSource = null;
            selectedRaceSession.Clear();



            if (selectedRaceClass.Count > 1)
            {
                RaceS_Add.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;

                Race_Edit.IsEnabled = false;


            }
            else if (selectedRaceClass.Count == 1)
            {
                RaceS_Add.IsEnabled = true;
                RaceS_Delete.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;

                Race_Add.IsEnabled = true;
                Race_Edit.IsEnabled = true;
                Race_Delete.IsEnabled = true;



                Race_Session_List.ItemsSource = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];
            }


        }

        private void RaceSessionItemClickEvent(object sender, SelectionChangedEventArgs e)
        {
            // selectedRaceSession = e.AddedItems.Cast<RaceSession>().ToList();
            if (e.RemovedItems.Count > 0)
                selectedRaceSession.Remove((RaceSession)e.RemovedItems[0]);
            if (e.AddedItems.Count > 0)
                selectedRaceSession.Add((RaceSession)e.AddedItems[0]);

            if (selectedRaceSession.Count > 1)
            {
                RaceS_Edit.IsEnabled = false;
            }
            else if (selectedRaceSession.Count == 1)
            {
                RaceS_Edit.IsEnabled = true;
                RaceS_Delete.IsEnabled = true;
            }

        }


        private void EventItemClickEvent(object sender, SelectionChangedEventArgs e)
        {
            // selectedRaceSession = e.AddedItems.Cast<RaceSession>().ToList();
            if (e.RemovedItems.Count > 0)
                selectedEvent.Remove((EventsBean)e.RemovedItems[0]);
            if (e.AddedItems.Count > 0)
                selectedEvent.Add((EventsBean)e.AddedItems[0]);


            Race_Session_List.ItemsSource = null;

            Delete_Event.IsEnabled = true;

            if (selectedEvent.Count > 1)
            {
                EventName.Text = "";
                EventPlace.Text = "";

                Race_List.ItemsSource = null;
                Race_Session_List.ItemsSource = null;

                Race_Add.IsEnabled = false;
                Race_Edit.IsEnabled = false;
                Race_Delete.IsEnabled = false;

                RaceS_Add.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;

                Save_Event.IsEnabled = false;
                Clear_Event.IsEnabled = false;

            }
            else if (selectedEvent.Count == 1)
            {

                Race_Add.IsEnabled = true;

                // f***king method
                Dictionary<RaceClass, List<RaceSession>> temp = new Dictionary<RaceClass, List<RaceSession>>();
                List<RaceClass> tempRcList = new List<RaceClass>();
                foreach (KeyValuePair<RaceClass, List<RaceSession>> kvp in eventDataList.ElementAt(eventListView.SelectedIndex).EventsRaceClass)
                {
                    RaceClass rc = new RaceClass();
                    rc.Name = kvp.Key.Name;
                    rc.Description = kvp.Key.Description;
                    rc.ClassId = kvp.Key.ClassId;
                    List<RaceSession> raceSessionListTemp = new List<RaceSession>();
                    foreach (RaceSession rs in kvp.Value)
                    {
                        RaceSession tempRs = new RaceSession();
                        tempRs.Name = rs.Name;
                        tempRs.Date = rs.Date;
                        tempRs.Type = rs.Type;
                        tempRs.Distance = rs.Distance;
                        tempRs.LapNumber = rs.LapNumber;
                        tempRs.Time = rs.Time;
                        tempRs.SchedTime = rs.SchedTime;

                        raceSessionListTemp.Add(tempRs);

                    }

                    temp.Add(rc, raceSessionListTemp);
                    tempRcList.Add(rc);
                }
                // end  f***king method



                //eventDataList = eventDataList_original;
                raceClassWithSessionList = temp;//eventDataList.ElementAt(eventListView.SelectedIndex).EventsRaceClass
                list_raceClass = tempRcList;//eventDataList.ElementAt(eventListView.SelectedIndex).RaceClassLists




                //Race_List.ItemsSource = getListOfRaceClass();
                Race_List.ItemsSource = list_raceClass;
                Race_Session_List.ItemsSource = null;

                RaceS_Add.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;



                Race_Edit.IsEnabled = false;
                Race_Delete.IsEnabled = false;

                Save_Event.IsEnabled = true;
                Clear_Event.IsEnabled = true;


                EventName.Text = selectedEvent.ElementAt(0).EventName;
                EventPlace.Text = selectedEvent.ElementAt(0).Place;
            }

        }


        private void addRaceClassInfo(object sender, RaceEventArgs e)
        {
            if (!e.RaceName.Equals("") || !e.RaceDescription.Equals(""))
            {
                RaceClass dummy = new RaceClass { Name = e.RaceName, Description = e.RaceDescription };


                raceClassWithSessionList.Add(dummy, new List<RaceSession>());

                list_raceClass.Add(dummy);

                selectedRaceClass.Clear();
                Race_List.ItemsSource = null;
                //Race_List.ItemsSource = getListOfRaceClass();
                Race_List.ItemsSource = list_raceClass;


                Race_Session_List.ItemsSource = null;
                RaceS_Add.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;

            }
        }

        private void editRaceClassInfo(object sender, RaceEventArgs e)
        {
            if (!e.RaceName.Equals("") || !e.RaceDescription.Equals(""))
            {
                // int i = Race_List.SelectedIndex;
                // list_raceClass.RemoveAt(i);
                //list_raceClass.Insert(i, new RaceClass { No = i+1, Name = e.RaceName, Description = e.RaceDescription });
                //Race_List.ItemsSource = null;
                // Race_List.ItemsSource = list_raceClass;


                //List<RaceClass> rcList = getListOfRaceClass();
                // RaceClass rc = rcList.ElementAt(Race_List.SelectedIndex);

                RaceClass rc = list_raceClass.ElementAt(Race_List.SelectedIndex);
                rc.Name = e.RaceName;
                rc.Description = e.RaceDescription;

                selectedRaceClass.Clear();
                Race_List.ItemsSource = null;
                Race_List.ItemsSource = list_raceClass;

                raceClassWithSessionList.Count();



                Race_Session_List.ItemsSource = null;
                RaceS_Add.IsEnabled = false;
                RaceS_Edit.IsEnabled = false;
                RaceS_Delete.IsEnabled = false;
            }
        }

        private void addRaceSessionInfo(object sender, RaceEventArgs e)
        {
            if (!e.RaceName.Equals("") || !e.RaceDescription.Equals("") || !e.Distance.Equals("") || !e.LapNumber.Equals("") || !e.Date.Equals("") || !e.Time.Equals("") || !e.SchedTime.Equals(""))
            {
                RaceSession dummyRaceSession = new RaceSession { Name = e.RaceName, Type = e.RaceDescription, Date = e.Date, Distance = Convert.ToInt32(e.Distance), LapNumber = Convert.ToInt32(e.LapNumber), Time = Convert.ToInt32(e.Time), SchedTime = e.SchedTime};

                List<RaceSession> dummy = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];
                dummy.Add(dummyRaceSession);

                selectedRaceSession.Clear();
                Race_Session_List.ItemsSource = null;
                Race_Session_List.ItemsSource = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];

            }
        }

        private void editRaceSessionInfo(object sender, RaceEventArgs e)
        {
            if (!e.RaceName.Equals("") || !e.RaceDescription.Equals("") || !e.Date.Equals("") || !e.Distance.Equals("") || !e.Time.Equals("") || !e.SchedTime.Equals(""))
            {
                /*int i = Race_Session_List.SelectedIndex;
                list_raceSession.RemoveAt(i);
                list_raceSession.Insert(i, new RaceSession { Name = e.RaceName, Type = e.RaceDescription, Date = e.Date });
                Race_Session_List.ItemsSource = null;
                Race_Session_List.ItemsSource = list_raceSession;*/

                List<RaceSession> dummy = raceClassWithSessionList[selectedRaceClass.ElementAt(0)];
                RaceSession rs = dummy.ElementAt(Race_Session_List.SelectedIndex);
                rs.Name = e.RaceName;
                rs.Type = e.RaceDescription;
                rs.Date = e.Date;
                rs.Distance = Convert.ToInt32(e.Distance);
                rs.Time = Convert.ToInt32(e.Time);
                rs.SchedTime = e.SchedTime;

                selectedRaceSession.Clear();
                Race_Session_List.ItemsSource = null;
                Race_Session_List.ItemsSource = dummy;


            }
        }


        private List<RaceClass> getListOfRaceClass()
        {
            List<RaceClass> raceClass = new List<RaceClass>();

            foreach (RaceClass rc in raceClassWithSessionList.Keys)
            {
                raceClass.Add(rc);
            }

            return raceClass;
        }

        private void EventName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }



}
