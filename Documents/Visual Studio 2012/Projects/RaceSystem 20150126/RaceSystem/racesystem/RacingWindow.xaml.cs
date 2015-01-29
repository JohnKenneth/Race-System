using System;
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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Impinj.OctaneSdk;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Threading;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for RacingWindow.xaml
    /// </summary>
    public partial class RacingWindow// : Window
    {
        // Create an instance of the ImpinjReader class.
        static ImpinjReader reader = null;
        public const string readerHostname = "ipj-rev-r420-usa1m1";//"192.168.1.134";
        int classId = 0;
        int sessionId = 0;
        private static string currentTag = "";
        private int distance = 0;
        private int lapNumber = 0;
        private Dictionary<String, Object> raceDesc = null;

        Boolean isStarted = false;

        DispatcherTimer _timer;
        TimeSpan _time;

        private static AsyncObservableCollection<RacersBean> RacerList = new AsyncObservableCollection<RacersBean>();
        /*public ObservableCollection<RacersBean> RacerList
        {
            get { return _racerList; }
            set
            {
                _racerList = value;
                OnPropertyChanged("RacerList");
            }
        }


        #region OnCollectionChanged Members

        public event NotifyCollectionChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void OnPropertyChanged(RacersBean propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new NotifyCollectionChangedEventArgs(propertyName));
            }
        }

        #endregion*/

        public DBConnectionRacing con = new DBConnectionRacing();
        public RacingWindow(ImpinjReader rdr)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            reader = rdr;
            reader.TagsReported += OnTagsReported;
        }

        public void loadRacers(int classId, int sessionId)
        {
            this.classId = classId;
            this.sessionId = sessionId;
            RacerList = con.selectRacers(classId, Convert.ToInt32(sessionId));
            tblRacingInfo.ItemsSource = RacerList;

            BindingOperations.EnableCollectionSynchronization(RacerList, new object());
            BindingOperations.EnableCollectionSynchronization(tblRacingInfo.ItemsSource, new object());

            raceDesc = con.getRaceDescription(sessionId);
            lblEventName.Content = raceDesc["EventName"];
            lblClassName.Content = raceDesc["ClassName"];
            lblSessionName.Content = raceDesc["SessionName"];
            lblTime.Content = Convert.ToInt32(raceDesc["Time"]);

            this.distance = Convert.ToInt32(raceDesc["Distance"]);
            this.lapNumber = Convert.ToInt32(raceDesc["LapNumber"]);
            //initializeRFIDReader();
        }
        /*
        private void initializeRFIDReader()
        {
            try
            {
                // Connect to the reader.
                // Change the ReaderHostname constant in SolutionConstants.cs 
                // to the IP address or hostname of your reader.
                reader.Connect(readerHostname);

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

                // Set the reader mode, search mode and session
                settings.ReaderMode = ReaderMode.AutoSetDenseReader;
                settings.SearchMode = SearchMode.DualTarget;
                settings.Session = 2;

                // Enable antenna #1. Disable all others.
                settings.Antennas.DisableAll();
                settings.Antennas.GetAntenna(1).IsEnabled = true;

                // Set the Transmit Power and 
                // Receive Sensitivity to the maximum.
                settings.Antennas.GetAntenna(1).MaxTransmitPower = true;
                settings.Antennas.GetAntenna(1).MaxRxSensitivity = true;
                // You can also set them to specific values like this...
                //settings.Antennas.GetAntenna(1).TxPowerInDbm = 20;
                //settings.Antennas.GetAntenna(1).RxSensitivityInDbm = -70;

                // Apply the newly modified settings.
                reader.ApplySettings(settings);

                // Assign the TagsReported event handler.
                // This specifies which method to call
                // when tags reports are available.
                reader.TagsReported += OnTagsReported;

                /*

                // Start reading.
                reader.Start();
                 
                
                // Wait for the user to press enter.
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();

                // Stop reading.
                reader.Stop();

                // Disconnect from the reader.
                reader.Disconnect();
            }
            catch (OctaneSdkException e)
            {
                // Handle Octane SDK errors.
                Console.WriteLine("Octane SDK exception: {0}", e.Message);
            }
            catch (Exception e)
            {
                // Handle other .NET errors.
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }*/
            /*
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var racer = RacerList.Single(a => a.racerName == "Kenneth");
            RacerList.RemoveAt(RacerList.IndexOf((Racers)racer));
            String timeIn = DateTime.Now.ToString("h:mm:ss tt");
            RacerList.Insert(1, new Racers { racerName = "Kenneth", lapTime =  });

            System.Windows.Forms.MessageBox.Show("" + String.Format("ID={0}", racer.racerName));
            for (int i = 0; i < RacerList.Count; i++)
            {
                if (RacerList[i].racerName == racer.racerName)
                {
                    RacerList.RemoveAt(i);
                }
            }
           
            //RacerList.Remove((Racers)RacerList.Where(a => a.racerName == "Kenneth"));
            /*
            //get the target item
            Racers targetItem = (Racers)RacerList.SelectedItem;
            
            //remove the source from the list
            RacerList.Remove(RacerList.Where(a => a.racerName == "Kenneth"));

            //get target index
            var targetIndex = RacerList.IndexOf(targetItem);

            //move source at the target's location
            RacerList.Insert(targetIndex, DraggedItem);

            //select the dropped item
            RacerList.SelectedItem = DraggedItem;
        }*/

        private void recordLap(String tag)
        {
            tag = tag.Replace(" ", String.Empty);
            if (!isStarted)// || currentTag == tag)
                return;
            //Console.WriteLine(tag);

            var task = Task.Factory.StartNew(() =>
            {
                try
                {
                    // get Racer
                    var racerChecker = RacerList.Where(a => a.rfidTag == tag);

                    if (racerChecker.Count() == 0)
                        return;

                    RacersBean racer = racerChecker.Last();

                    int prevIndex = RacerList.IndexOf(racer);

                    // Lap Number Validation
                    if (racer.lapNumber + 1 > this.lapNumber)
                        return;

                    double laptTime = Math.Round(DateTime.Now.Subtract(racer.timeOfLap).TotalSeconds, 2);
                    //System.Windows.Forms.MessageBox.Show("Lap Time: " + racer.racerName + "  " + racer.timeOfLap + "  " + DateTime.Now + "  " + racer.lapTime + "  " + 1 + "  " + DateTime.Now.Subtract(racer.timeOfLap).TotalSeconds);
                    // Lap Time Validation
                    if (laptTime < 5)
                        return;

                    //System.Windows.Forms.MessageBox.Show("1 " + racer.racerName);
                    RacerList.RemoveAt(prevIndex);
                    //System.Windows.Forms.MessageBox.Show("2 " + racer.racerName);

                    // set Lap Number
                    racer.lapNumber = racer.lapNumber + 1;

                    // set Total Lap Time
                    racer.totalTime = racer.totalTime + laptTime;

                    // set Lap Time
                    racer.lapTime = laptTime;
                    
                    // set Time of Lap
                    racer.timeOfLap = DateTime.Now;

                    // set Best Lap Time
                    racer.bestLapTime = racer.bestLapTime > racer.lapTime || racer.bestLapTime == 0 ? racer.lapTime : racer.bestLapTime;



                    // set Lap Speed
                    racer.lapSpeed = Math.Round(this.distance / racer.lapTime, 2);

                    // set Best Lap Speed
                    racer.bestLapSpeed = racer.bestLapSpeed < racer.lapSpeed || racer.bestLapSpeed == 0 ? racer.lapSpeed : racer.bestLapSpeed;


                    // set Position
                    var greatEqualLap = RacerList.Where(a => a.lapNumber >= racer.lapNumber);
                    int racerPosition = 0;
                    if (greatEqualLap.Count() != 0)
                    {
                        //var greatEqualTime = greatEqualLap.Where(a => Convert.ToDateTime(a.lapTime) >= Convert.ToDateTime(racer.lapTime));
                        //Racers racerFront = racerFronts.ElementAt();
                        //System.Windows.Forms.MessageBox.Show("" + RacerList.IndexOf(greatEqualTime.Last()));
                        //racerPosition = RacerList.IndexOf(greatEqualTime.Last()) + 1;
                        //System.Windows.Forms.MessageBox.Show("" + racerPosition);
                        //if (racerPosition < 0)
                        racerPosition = RacerList.IndexOf(greatEqualLap.Last()) + 1;
                    }
                    racer.positionNumber = racerPosition + 1;
                    foreach (RacersBean inBackRacer in RacerList.Where(a => (a.positionNumber > racer.positionNumber - 1) && (a.positionNumber <= prevIndex + 1)))
                    {
                        //inBackRacer.positionNumber = inBackRacer.positionNumber + 1;
                        //System.Windows.Forms.MessageBox.Show("" + inBackRacer.racerName + " " +inBackRacer.positionNumber);
                        RacerList.ElementAt(RacerList.IndexOf(inBackRacer)).positionNumber = inBackRacer.positionNumber + 1;
                    }

                    RacerList.Insert(racerPosition, racer);
                    con.recordLapDetails(racer);

                    if (racer.positionNumber == RacerList.Count() && racer.lapNumber == this.lapNumber)
                    {
                        MessageBox.Show("RACE FINISHED", "Race Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        //lblStatus.Content = "Finished";
                        //btnStartRace.IsEnabled = true;
                        Action action = () =>
                            {
                                btnStartRace.IsEnabled = true;
                                lblStatus.Content = "Finished";
                            };
                        Dispatcher.Invoke(action);
                    }
                    currentTag = tag;
                    Action action2 = () => this.tblRacingInfo.Items.Refresh();
                    Dispatcher.Invoke(action2);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            task.Wait();
        }

        private void startRace(object sender, RoutedEventArgs eArg)
        {
            if (btnStartRace.Content.Equals("Start Race"))
            {
                DateTime startTime = DateTime.Now;

                _time = TimeSpan.FromMinutes(Convert.ToDouble(raceDesc["Time"]));

                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    lblTime.Content = _time.ToString("c");
                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        // Stop reading.
                        reader.Stop();

                        MessageBox.Show("Time has ran out", "Time Ends", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        btnStartRace.Content = "Exit";
                    }
                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);

                _timer.Start();

                foreach (RacersBean allRacers in RacerList)
                {
                    allRacers.timeOfLap = startTime;
                }

                try
                {
                    // Start reading.
                    reader.Start();

                    MessageBox.Show("START RACE", "Race Information", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    lblStatus.Content = "Racing";
                    btnStartRace.Content = "Finish";
                    btnStartRace.IsEnabled = false;
                    btnReset.IsEnabled = true;
                    isStarted = true;
                    
      
                }
                catch (OctaneSdkException e)
                {
                    // Handle Octane SDK errors.
                    Console.WriteLine("Octane SDK exception: {0}", e.Message);
                }
                catch (Exception e)
                {
                    // Handle other .NET errors.
                    Console.WriteLine("Exception : {0}", e.Message);
                }
            }
            else
            {
                if (lblStatus.Content.Equals("Racing"))
                {
                    MessageBoxResult res = MessageBox.Show("Are You sure You want to Close while Racing", "Race Information", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (!res.ToString().Equals("Yes"))
                        return;
                }

                // Stop reading.
                reader.Stop();
                
                this.Close();
            }
        }

        private void resetRace(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult res = MessageBox.Show("Are You sure You want Reset the Race", "Race Information", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (!res.ToString().Equals("Yes"))
                    return;

                // Stop reading.
                reader.Stop();
                
                con.resetRace(Convert.ToString(sessionId));
                RacerList = con.selectRacers(classId, sessionId);
                tblRacingInfo.ItemsSource = RacerList;
                lblTime.Content = Convert.ToInt32(raceDesc["Time"]);
                currentTag = "";
                //this.tblRacingInfo.Items.Refresh();
                _timer.Stop();
                isStarted = false;

                btnStartRace.IsEnabled = true;
                lblStatus.Content = "Race Reset";
                btnStartRace.Content = "Start Race";
                btnReset.IsEnabled = false;
            }
            catch (OctaneSdkException ex)
            {
                // Handle Octane SDK errors.
                Console.WriteLine("Octane SDK exception: {0}", ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Operation exception: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other .NET errors.
                Console.WriteLine("Exception : {0}", ex.Message);
            }
        }

        // Reading of Tags
        public void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            // This event handler is called asynchronously 
            // when tag reports are available.
            // Loop through each tag in the report 
            // and print the data.
            foreach (Tag tag in report)
            {
                String tagNo = tag.Epc.ToString();
                recordLap(tagNo);
                //Console.WriteLine("Antenna : {0}, EPC : {1} ",
                  //                  tag.AntennaPortNumber, tag.Epc);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            recordLap("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            recordLap("2");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            recordLap("3");
        }
    }
}
