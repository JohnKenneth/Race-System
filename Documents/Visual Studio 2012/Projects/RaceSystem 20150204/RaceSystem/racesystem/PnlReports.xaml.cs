using System;
using System.Collections.Generic;
using System.Globalization;
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
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for PnlReports.xaml
    /// </summary>
    public partial class PnlReports : UserControl
    {
        DBConnectionReports reportCon;
        DBConnectionDriver driverCon;
        DBConnectionEvents eventCon;
        public PnlReports()
        {
            InitializeComponent();
            reportCon = new DBConnectionReports();
            driverCon = new DBConnectionDriver();
            eventCon = new DBConnectionEvents();
        }

        private void selectDriver(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                DriverDetailsBean SelectedDriver = (DriverDetailsBean)e.AddedItems[0];
                this.Team_ID.Text = SelectedDriver.Team_id;
                this.Name_txt.Text = SelectedDriver.Name;
                this.Eid_txt.Text = SelectedDriver.Email;
                this.Contact_txt.Text = SelectedDriver.Contact_no;
                this.Address_txt.Text = SelectedDriver.Address;
                this.Gender_txt.Text = SelectedDriver.Gender;
                this.Birthday_txt.Text = SelectedDriver.Birthdate;
                this.age_txt.Text = SelectedDriver.Age;
                this.Vehicle_txt.Text = SelectedDriver.Vehicle_model;
                this.Plate_txt.Text = SelectedDriver.Plate_no;
                this.License_txt.Text = SelectedDriver.License_no;

                tblRaceReports.ItemsSource = reportCon.getDriverRacingDetails(SelectedDriver.Driver_Id);
                tblRaceReports.Items.Refresh();
            }

        }

        public void setDriverList()
        {
            Driver_List.ItemsSource = null;
            Driver_List.ItemsSource = driverCon.GetAllList();

            EventList.ItemsSource = null;
            EventList.ItemsSource = eventCon.selectRaceSession("%%");
        }

        private void selectEvent(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                RaceSession selectedSession = (RaceSession)e.AddedItems[0];
                this.tfEventName.Text = selectedSession.EventName;
                this.tfClassName.Text = selectedSession.ClassName;
                this.tfSessionName.Text = selectedSession.Name;
                this.tfRaceType.Text = selectedSession.Type;
                this.tfDate.Text = selectedSession.Date;
                this.tfLapNumber.Text = Convert.ToString(selectedSession.LapNumber);
                this.tfPlace.Text = selectedSession.Place;
                this.tfDescription.Text = selectedSession.Description;
                this.tfDistance.Text = Convert.ToString(selectedSession.Distance);

                tblEventRaceReports.ItemsSource = reportCon.getEventRacingDetails(selectedSession.SessionId);
                tblEventRaceReports.Items.Refresh();
            }
        }


    }



    public class DriverProfileBean
    {
        private DriverDetailsBean driverDetails;
        private List<DriversRacingReportBean> racingDetails;


        public DriverProfileBean()
        {

        }

        public DriverProfileBean(DriverDetailsBean driverDetails, List<DriversRacingReportBean> racingDetails)
        {
            this.driverDetails = driverDetails;
            this.racingDetails = racingDetails;
        }

        public DriverDetailsBean DriverDetails
        {
            get { return this.driverDetails; }
            set
            {
                this.driverDetails = value;
            }
        }

        public List<DriversRacingReportBean> RacingDetailsList
        {
            get
            {
                return this.racingDetails;
            }
            set
            {
                this.racingDetails = value;

            }
        }
    }
}
