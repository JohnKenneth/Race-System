using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RaceSessionForm.xaml
    /// </summary>
    public partial class RaceSessionForm : Window
    {
        public delegate void RaceUpdateHandler(object sender, RaceEventArgs e);

        public event RaceUpdateHandler RaceUpdated;

        public RaceSessionForm()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

            if (TSession_Name.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LSession_Name.Content + " cannot be empty.");
            }
            else if (TSession_Type.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LSession_Type.Content + " cannot be empty.");
            }
            else if (TSession_Distance.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LSession_Distance.Content + " cannot be empty.");
            }
            else if (TSession_Time.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LSession_Time.Content + " cannot be empty.");
            }
            else if (TSession_LapNumber.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LSession_LapNumber.Content + " cannot be empty.");
            }
            else if (TDate.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LDate.Content + " cannot be empty.");
            }
            else if (tfSchedTime.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + lblSchedTime.Content + " cannot be empty.");
            }

            else if(!Regex.IsMatch(TSession_Time.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Please input numerical values only for Time");
                return;
            }

            else if (!Regex.IsMatch(tfSchedTime.Text, @"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9] [A,P]M$"))
            {
                MessageBox.Show("Invalid Scheduled Time");
                return;
            }
           
            else
            {
                string raceSession = TSession_Name.Text;
                string raceType = TSession_Type.Text;
                string raceDate = TDate.Text;
                string distance = TSession_Distance.Text;
                string lapNumber = TSession_LapNumber.Text;
                string time = TSession_Time.Text;
                string schedTime = tfSchedTime.Text;


                this.Close();
                RaceEventArgs rea = new RaceEventArgs(raceSession, raceType, raceDate, distance, lapNumber, time, schedTime);
                RaceUpdated(this, rea);
            }




        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void setDefault(string name, string description, string date, int distance, int lapNumber, int time, string schedTime)
        {

            TSession_Name.Text = name;
            TSession_Type.Text = description;


            /*DateTime d = Convert.ToDateTime(date);
            string format = "yyyy/MM/dd";
            TDate.Text = d.ToString(format);*/
            TDate.Text = date;
            TSession_Distance.Text = Convert.ToString(distance);
            TSession_LapNumber.Text = Convert.ToString(lapNumber);
            TSession_Time.Text = Convert.ToString(time);
            tfSchedTime.Text = schedTime;
        }


        /*private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? dt = TDate.SelectedDate;

            string ei = dt.Value.ToShortDateString();

            DateTime d = Convert.ToDateTime(ei);
            string format = "yyyy/MM/dd";
            Console.WriteLine(d.ToString(format));
            TDate.Text = d.ToString(format);

        }*/
    }
}
