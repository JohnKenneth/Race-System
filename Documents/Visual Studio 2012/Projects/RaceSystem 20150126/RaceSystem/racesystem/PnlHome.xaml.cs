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
using Impinj.OctaneSdk;
using System.Net;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for PnlHome.xaml
    /// </summary>
    public partial class PnlHome : UserControl
    {
        DBConnectionEvents eventConnection;
        List<RaceSession> allEvents = null;
        Dictionary<RaceSession, Button> allEventButtons = new Dictionary<RaceSession, Button>();

        // Create an instance of the ImpinjReader class.
        static ImpinjReader reader = new ImpinjReader();
        bool isConnected = false;

        public PnlHome()
        {
            InitializeComponent();
            /*
            // Start Timer
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();*/
        }

        public void loadPage()
        {
            // Clear
            pnlEventButtons.Children.Clear();
            pnlEventLabels.Children.Clear();
            allEventButtons.Clear();

            // Load Header
            //lblHeader.Content = "Todays Race Events: ";

            // Load Todays Event
            eventConnection = new DBConnectionEvents();
            allEvents = eventConnection.getEventToday();

            if (allEvents.Count() > 0)
            {
                foreach (RaceSession session in allEvents)
                {
                    // Labels
                    Label newLbl = new Label();
                    newLbl.Content = session.Name+" ("+session.SchedTime+")";
                    newLbl.HorizontalContentAlignment = HorizontalAlignment.Right;
                    newLbl.Margin = new Thickness(0, 2, 0, 2);
                    pnlEventLabels.Children.Add(newLbl);

                    // Buttons
                    Button newBtn = new Button();
                    newBtn.Margin = new Thickness(0, 4, 0, 4);
                    newBtn.HorizontalAlignment = HorizontalAlignment.Left;
                    newBtn.Click += (s, e) => 
                        {
                            if (!isConnected)
                            {
                                System.Windows.Forms.MessageBox.Show("Please Connect to the RFID Reader First");
                                return;
                            }
                            RacingWindow raceWindow = new RacingWindow(reader);
                            Console.WriteLine(session.ClassId + "  " + session.SessionId);
                            raceWindow.loadRacers(session.ClassId, Convert.ToInt32(session.SessionId));
                            raceWindow.Show();
                        };
                    if (DateTime.Now.Date.CompareTo(Convert.ToDateTime(session.Date)) > 0)
                        newBtn.IsEnabled = false;

                    newBtn.Content = "Start Race";//session.Date;
                    newBtn.Name = "btnStartSession" + session.SessionId;

                    pnlEventButtons.Children.Add(newBtn);
                    
                    allEventButtons.Add(session, newBtn);
                }

            }
            else
            {

            }
            // Get host name
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPAddress[] addresslist = Dns.GetHostAddresses(strHostName);

            foreach (IPAddress theaddress in addresslist)
            {
                Console.WriteLine(theaddress.ToString());
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btnConnect.Content.ToString() == "Connect")
            {
                if (tfIPAddress.Text.ToString() == "")
                {
                    System.Windows.Forms.MessageBox.Show("RFID Reader Address is Required");
                    return;
                }
                initializeRFIDReader();
                if (isConnected)
                {
                    tfIPAddress.IsEnabled = false;
                    btnConnect.Content = "Disonnect";
                }
            }
            else
            {
                reader.Stop();
                reader.Disconnect();
                isConnected = false;

                tfIPAddress.IsEnabled = true;
                btnConnect.Content = "Connect";
            }
        }

        private void initializeRFIDReader()
        {
            try
            {
                // Connect to the reader.
                // Change the ReaderHostname constant in SolutionConstants.cs 
                // to the IP address or hostname of your reader.
                reader.Connect(tfIPAddress.Text.ToString());

                // Get the default settings
                // We'll use these as a starting point
                // and then modify the settings we're 
                // interested in.
                Settings settings = reader.QueryDefaultSettings();

                // Tell the reader to include the antenna number
                // in all tag reports. Other fields can be added
                // to the reports in the same way by setting the 
                // appropriate Report.IncludeXXXXXXX property.
                settings.Report.IncludeAntennaPortNumber = true;

                // Send a tag report for every tag read.
                settings.Report.Mode = ReportMode.Individual;

                // Set the reader mode, search mode and session
                settings.ReaderMode = ReaderMode.AutoSetDenseReader;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;
                settings.TagPopulationEstimate = 100;


                // Enable antenna #1. Disable all others.
                //settings.Antennas.DisableAll();
                settings.Antennas.GetAntenna(1).IsEnabled = true;
                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(1).MaxTxPower = true;
                settings.Antennas.GetAntenna(1).MaxRxSensitivity = true;
                // You can also set them to specific values like this...
                settings.Antennas.GetAntenna(1).TxPowerInDbm = 20;
                settings.Antennas.GetAntenna(1).RxSensitivityInDbm = -70;
                
                // Enable antenna #2.
                settings.Antennas.GetAntenna(2).IsEnabled = true;
                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(2).MaxTxPower = true;
                settings.Antennas.GetAntenna(2).MaxRxSensitivity = true;
                // You can also set them to specific values like this...
                settings.Antennas.GetAntenna(2).TxPowerInDbm = 20;
                settings.Antennas.GetAntenna(2).RxSensitivityInDbm = -70;

                // Enable antenna #3.
                settings.Antennas.GetAntenna(3).IsEnabled = true;
                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(3).MaxTxPower = true;
                settings.Antennas.GetAntenna(3).MaxRxSensitivity = true;
                // You can also set them to specific values like this...
                settings.Antennas.GetAntenna(3).TxPowerInDbm = 20;
                settings.Antennas.GetAntenna(3).RxSensitivityInDbm = -70;

                // Enable antenna #4.
                settings.Antennas.GetAntenna(4).IsEnabled = true;
                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(4).MaxTxPower = true;
                settings.Antennas.GetAntenna(4).MaxRxSensitivity = true;
                // You can also set them to specific values like this...
                settings.Antennas.GetAntenna(4).TxPowerInDbm = 20;
                settings.Antennas.GetAntenna(4).RxSensitivityInDbm = -70;
                

                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                System.Windows.Forms.MessageBox.Show("Connecting Successful");
                isConnected = true;
                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.

                /*

                // Start reading.
                reader.Start();
                 
                
                // Wait for the user to press enter.
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();

                // Stop reading.
                reader.Stop();

                // Disconnect from the reader.
                reader.Disconnect();*/
            }
            catch (OctaneSdkException e)
            {
                System.Windows.Forms.MessageBox.Show("Error Connecting: Invalid IP Address");
                // Handle Octane SDK errors.
                Console.WriteLine("Octane SDK exception: {0}", e.Message);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error Connecting: Invalid IP Address");
                // Handle other .NET errors.
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }

        /*
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (RaceSession session in allEventButtons.Keys)
            {
                allEventButtons[session].IsEnabled = true;
            }

            // code goes here
        }*/
    }
}
