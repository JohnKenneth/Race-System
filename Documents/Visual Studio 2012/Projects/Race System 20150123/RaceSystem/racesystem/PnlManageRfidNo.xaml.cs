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
using ThingMagic;
using System.Threading;

namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for ManageRfid.xaml
    /// </summary>
    public partial class PnlManageRfidNo : UserControl
    {
       private DBConnectionRfid dbConnection;
        private List<RfidBean> selectedRfid;
        private Boolean readBool = false;

        private Reader r;
        private Thread thread;

        public PnlManageRfidNo()
        {
            InitializeComponent();
            dbConnection = new DBConnectionRfid();
        }

        public void setData()
        {
            populateRfidList();

            Delete_RFID.IsEnabled = true;
            Start_RFID.IsEnabled = true;
            Stop_RFID.IsEnabled = false;
            readBool = false;

            if (r != null)
            {
                r.StopReading();
                r.Destroy();
            }
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (comPort.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Please enter the Com Port Number of the Reader.");
                return;
            }

            try
            {
               

                readBool = true;
                string a = "tmr:///" + comPort.Text;
                r = Reader.Create(a);
                
                    r.Connect();
                    if (Reader.Region.UNSPEC == (Reader.Region)r.ParamGet("/reader/region/id"))
                    {
                        Reader.Region[] supportedRegions = (Reader.Region[])r.ParamGet("/reader/region/supportedRegions");
                        if (supportedRegions.Length < 1)
                        {
                            throw new FAULT_INVALID_REGION_Exception();
                        }
                        else
                        {
                            r.ParamSet("/reader/region/id", supportedRegions[0]);
                        }
                    }

                    Stop_RFID.IsEnabled = true;
                    Delete_RFID.IsEnabled = false;
                    Start_RFID.IsEnabled = false;
                    readRFID(RFID_list, selectedRfid);
               
            }
            catch (ReaderException re)
            {
                System.Windows.Forms.MessageBox.Show("Error: The given port name is not valid as a serial port");
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: The given port name is not valid as a serial port");
            }
        }


        private void RFIDList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
                selectedRfid.Remove((RfidBean)e.RemovedItems[0]);
            if (e.AddedItems.Count > 0)
                selectedRfid.Add((RfidBean)e.AddedItems[0]);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Delete_RFID.IsEnabled = true;
            Start_RFID.IsEnabled = true;
            Stop_RFID.IsEnabled = false;
           readBool = false;

            
             r.StopReading();
             r.Destroy();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            dbConnection.removeRifdTag(selectedRfid);
            populateRfidList();
            System.Windows.Forms.MessageBox.Show("RFID No/s is successfully removed.");

        }

        private void populateRfidList()
        {
            List<RfidBean> list = dbConnection.getAllRfidTag();
            selectedRfid = new List<RfidBean>();
            RFID_list.ItemsSource = list;
        }

        private void readRFID(ListView view,List<RfidBean> bean)
        {
           /* r.StartReading();

                 while (readBool)
                 {
                     TagReadData[] tagReads;
                     // Read tags
                     tagReads = r.Read(500);
                     // Print tag reads
                     if (tagReads.Count() > 0)
                     {

                         foreach (TagReadData tr in tagReads)
                         {
                             Console.WriteLine(tr.Tag);
                             dbConnection.registerRfidTag(Convert.ToString(tr.Tag));
                         }
                         Thread.Sleep(1000);
                     }

                 }*/
          
            r.TagRead += delegate(Object sender, TagReadDataEventArgs e)
            {
              
                //Console.WriteLine("Background read: " + e.TagReadData.Tag);
                
                string tag = Convert.ToString(e.TagReadData.Tag);
                string tagtwo = tag.Substring(tag.IndexOf(":")+1);

                // Kenneth - tag filter
                var tagChecker = selectedRfid.Where(a => a.Rfid_Tag_No == tagtwo);

                if (tagChecker.Count() != 0)
                    return;
                // Kenneth - End

                List<RfidBean> list = dbConnection.registerRfidTag(tagtwo);
                 
                
                bean = new List<RfidBean>();
               // view.ItemsSource = list;

                Dispatcher.BeginInvoke(new Action(delegate() 
                  {
                      RFID_list.ItemsSource = null;
                      RFID_list.ItemsSource = list;
                  }));

           
            };

            // Create and add read exception listener
            r.ReadException += new EventHandler<ReaderExceptionEventArgs>(r_ReadException);

            r.StartReading();
           

            /*try
            {
                string a = "tmr:///COM20";
                // Create Reader object, connecting to physical device.
                // Wrap reader in a "using" block to get automatic
                // reader shutdown (using IDisposable interface).
                using (Reader r = Reader.Create(a))
                {
                    //Uncomment this line to add default transport listener.
                    //r.Transport += r.SimpleTransportListener;

                    r.Connect();

                    if (Reader.Region.UNSPEC == (Reader.Region)r.ParamGet("/reader/region/id"))
                    {
                        Reader.Region[] supportedRegions = (Reader.Region[])r.ParamGet("/reader/region/supportedRegions");
                        if (supportedRegions.Length < 1)
                        {
                            throw new FAULT_INVALID_REGION_Exception();
                        }
                        else
                        {
                            r.ParamSet("/reader/region/id", supportedRegions[0]);
                        }
                    }

                    /*while (readBool)
                    {
                        TagReadData[] tagReads;
                        // Read tags
                        tagReads = r.Read(500);
                        // Print tag reads
                        if (tagReads.Count() > 0)
                        {
                         
                            foreach (TagReadData tr in tagReads)
                            {
                                Console.WriteLine(tr.Tag);
                            }
                            Thread.Sleep(1000);
                        }

                    }


                }
            }
            catch (ReaderException re)
            {
                Console.WriteLine("Error: " + re.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }*/
        }
        static void r_ReadException(object sender, ReaderExceptionEventArgs e)
        {
            Console.WriteLine("Error: " + e.ReaderException.Message);
        }


    }
}
