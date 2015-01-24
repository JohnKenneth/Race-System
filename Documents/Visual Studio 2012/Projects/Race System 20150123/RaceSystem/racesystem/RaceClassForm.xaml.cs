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
    /// Interaction logic for RaceClass.xaml
    /// </summary>
    public partial class RaceClassForm : Window
    {

        public delegate void RaceUpdateHandler(object sender, RaceEventArgs e);

        public event RaceUpdateHandler RaceUpdated;

        public RaceClassForm()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

            if (TRace_Name.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LRace_Name.Content + " cannot be empty.");
            }
            else if (TRace_Description.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("" + LRace_Description.Content + " cannot be empty.");
            }
            else
            {
                string raceName = TRace_Name.Text;
                string raceDescription = TRace_Description.Text;


                this.Close();
                RaceEventArgs rea = new RaceEventArgs(raceName, raceDescription);
                RaceUpdated(this, rea);
            }

           

           
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void setDefault(string name, string description)
        {

            TRace_Name.Text = name;
            TRace_Description.Text = description;
        }
       
    }
}
