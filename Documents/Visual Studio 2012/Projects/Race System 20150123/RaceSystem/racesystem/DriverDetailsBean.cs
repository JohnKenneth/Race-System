using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    public class DriverDetailsBean
    {
        private string birthdate;
        public string DriverId { get; set; }
        public string Team_id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact_no { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Birthdate 
        {
           get
           {
               DateTime d = Convert.ToDateTime(birthdate);
                string format = "yyyy/MM/dd";
               
                birthdate = d.ToString(format);
                return birthdate;
            }
            set
            {
                this.birthdate = value;

            }
        
        }
        public string Age { get; set; }
        public string Vehicle_model { get; set; }
        public string Plate_no { get; set; }
        public string License_no { get; set; }
        public string Rfid_No { get; set; }
        public string Driver_Id { get; set; }
        public string Session_Id { get; set; }
        public string Class_Id { get; set; }

        public DriverDetailsBean()
        { }



        public DriverDetailsBean(String Team_id, String Name, String Email, String Contact_no, String Address, String Gender, String Birthdate, String Age, String Vehicle_model, String Plate_no, String License_no)//Constructor
        {
            this.Team_id = Team_id;
            this.Name = Name;
            this.Email = Email;
            this.Contact_no = Contact_no;
            this.Address = Address;
            this.Gender = Gender;
            this.Birthdate = Birthdate;
            this.Age = Age;
            this.Vehicle_model = Vehicle_model;
            this.Plate_no = Plate_no;
            this.License_no = License_no;

        }



    }
}
