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
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace RaceSystem
{
    /// <summary>
    /// Interaction logic for ManageDriver.xaml
    /// </summary>
    public partial class PnlDriver : UserControl
    {
       
        //List<DriverDetailsBean> driver_List;
       
        DriverDetailsBean SelectedDriver;
     
        DBConnectionDriver driverConnection;


        public void DriverList_method()
        {
            driverConnection = new DBConnectionDriver();
            
            Driver_List.ItemsSource = null;
            Driver_List.ItemsSource = driverConnection.GetAllList();
            ClearForm();

            

   
        }


        public PnlDriver()
        {
            InitializeComponent();
            //this.DataContext = new MainWindow();
           // DriverList_method();
        }

       

        private void BTNAdd_Click(object sender, RoutedEventArgs e)
        {


            if (TxtBxValidation())
                return;

            DriverDetailsBean bean = new DriverDetailsBean();
            bean.Team_id = this.Team_ID.Text;
            bean.Name = this.Name_txt.Text;
            bean.Email = this.Eid_txt.Text;
            bean.Contact_no = this.Contact_txt.Text;
            bean.Address = this.Address_txt.Text;
            bean.Gender = this.Gender_cmb.Text;
            bean.Birthdate =this.DatePicker.Text;
            bean.Age = this.age_txt.Text;
            bean.Vehicle_model = this.Vehicle_txt.Text;
            bean.Plate_no = this.Plate_txt.Text;
            bean.License_no = this.License_txt.Text;

            driverConnection.saveRacer(bean);
             
            Driver_List.ItemsSource = null;
            Driver_List.ItemsSource = driverConnection.GetAllList();
            ClearForm();    

            MessageBox.Show("Racer successfully saved.");   
        }

      

        private void DriverList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                SelectedDriver = (DriverDetailsBean)e.AddedItems[0];
                this.Team_ID.Text = SelectedDriver.Team_id;
                this.Name_txt.Text = SelectedDriver.Name;
                this.Eid_txt.Text = SelectedDriver.Email;
                this.Contact_txt.Text = SelectedDriver.Contact_no;
                this.Address_txt.Text = SelectedDriver.Address;
                this.Gender_cmb.Text = SelectedDriver.Gender;
                this.DatePicker.Text = SelectedDriver.Birthdate;
                this.age_txt.Text = SelectedDriver.Age;
                this.Vehicle_txt.Text = SelectedDriver.Vehicle_model;
                this.Plate_txt.Text = SelectedDriver.Plate_no;
                this.License_txt.Text = SelectedDriver.License_no;
            }

        }

        private void Name_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BTNClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {
            Name_txt.Text = string.Empty;
            Eid_txt.Text = string.Empty;
            Contact_txt.Text = string.Empty;
            Address_txt.Text = string.Empty;
            Gender_cmb.Text = string.Empty;
            age_txt.Text = string.Empty;
            Vehicle_txt.Text = string.Empty;
            Plate_txt.Text = string.Empty;
            License_txt.Text = string.Empty;
            Team_ID.Text = string.Empty;
            DatePicker.Text = string.Empty;
        
        }

        public Boolean TxtBxValidation()
        {
            if (string.IsNullOrEmpty(Name_txt.Text.Trim()))
            {
                MessageBox.Show("Name Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Eid_txt.Text.Trim()))
            {
                MessageBox.Show("Email Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Contact_txt.Text.Trim()))
            {
                MessageBox.Show("Contact No Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Address_txt.Text.Trim()))
            {
                MessageBox.Show("Address Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Gender_cmb.Text.Trim()))
            {
                MessageBox.Show("Gender Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(DatePicker.Text.Trim()))
            {
                MessageBox.Show("Birthday Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(age_txt.Text.Trim()))
            {
                MessageBox.Show("Age Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Vehicle_txt.Text.Trim()))
            {
                MessageBox.Show("Vehicle Model Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Plate_txt.Text.Trim()))
            {
                MessageBox.Show("Plate no. Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(License_txt.Text.Trim()))
            {
                MessageBox.Show("License no. Field is Empty!");
                return true;
            }

            if (string.IsNullOrEmpty(Team_ID.Text.Trim()))
            {
                MessageBox.Show("Team ID Field is Empty!");
                return true;
            }


            string strNm = Name_txt.Text;
            if (!Regex.IsMatch(strNm, @"^[a-zA-Z''-'\s]{1,40}$"))
            {
                MessageBox.Show("Please Insert  letter from A-Z a-z only ");
                return true;
            }


            string strEid = Eid_txt.Text;       
            if (!Regex.IsMatch(strEid, @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$"))
            {
                MessageBox.Show("Please input valid email address ");
                return true;
                //return false;
            }

            
            string strContact = Contact_txt.Text;
            //if (!Regex.IsMatch(strContact, @"/^([(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4})+|(\d)$/"))
            if(!Regex.IsMatch(strContact,"^09[0-9]{9}$"))
            {
              MessageBox.Show("Please input valid Contact Number ");
              return true;
            }


            string strAge = age_txt.Text;
            if (!Regex.IsMatch(strAge, @"^[0-9]+$"))
            {
                MessageBox.Show("Please input numerical values only ");
                return true;
            }

            return false;
        }


        private void BTNDelete_Click(object sender, RoutedEventArgs e)
        {

                driverConnection.removeRacer(SelectedDriver);

                Driver_List.ItemsSource = null;
                Driver_List.ItemsSource = driverConnection.GetAllList();
               
                ClearForm();

                MessageBox.Show("Racer successfully deleted.");
        }


        private void Eid_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Contact_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void age_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        /*private List<DriverDetailsBean>  GetAllList()
        {

            List<DriverDetailsBean> beanList = new List<DriverDetailsBean>();//local variable
            string queryString = "SELECT *  FROM  racing.drivers";
            // string constring = "datasource =localhost;port=3306;username=root;password=root";
             MySqlConnection connection = new MySqlConnection(constring);
           
                MySqlCommand command = new MySqlCommand(queryString, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        DriverDetailsBean DB = new DriverDetailsBean();


                       
                        DB.Team_id = (string)reader["team_id"];
                        DB.Name = (string)reader["name"];
                        DB.Email = (string)reader["email"];
                        DB.Contact_no = (string)reader["contact_no"];
                        DB.Address = (string)reader["address"];
                        DB.Gender = (string)reader["gender"];
                        DB.Birthdate = Convert.ToString(reader["birthdate"]);
                        DB.Age = (string)reader["age"];
                        DB.Vehicle_model = (string)reader["vehicle_model"];
                        DB.Plate_no = (string)reader["plate_no"];
                        DB.License_no = (string)reader["license_no"];
                        DB.Plate_no = (string)reader["plate_no"];
                        DB.License_no = (string)reader["license_no"];
                        DB.Driver_Id = Convert.ToString(reader["driver_id"]);
                        beanList.Add(DB);
                        
                    }
                    return beanList;
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                        
        }
         * */
        /*
        private Boolean isDriverExist()
        {
            if(SelectedDriver == null )
            return false;

            string queryString = "SELECT count(*) as pogi FROM  racing.drivers WHERE email = @email and plate_no =@plate_no and license_no=@license_no";
            string constring = "datasource =localhost;port=3306;username=root;password=root";
            MySqlConnection connection = new MySqlConnection(constring);
          
            MySqlCommand command = new MySqlCommand(queryString, connection);

            command.Parameters.AddWithValue("@email", this.Eid_txt.Text);
            command.Parameters.AddWithValue("@plate_no", this.Plate_txt.Text);
            command.Parameters.AddWithValue("@license_no", this.License_txt.Text);
           

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                
                if (Convert.ToInt32(reader.GetString(0)) > 0)
                {
                    return true;

                }

                return false;
            }



            return false;
        }
         * */

       
    
    }
}
