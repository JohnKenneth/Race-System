using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionDriver
    {

        public List<DriverDetailsBean> GetAllList()
        {

            List<DriverDetailsBean> beanList = new List<DriverDetailsBean>();//local variable
           // string queryString = "SELECT *  FROM  racing.drivers";
            // string constring = "datasource =localhost;port=3306;username=root;password=root";
            MySqlConnection connection = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_ALL_RACER, connection);
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


        public Boolean isDriverExist(DriverDetailsBean selectedDriver)
        {
            if (selectedDriver == null)
                return false;

            
            MySqlConnection connection = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACER, connection);

            command.Parameters.AddWithValue("@email", selectedDriver.Email);
            command.Parameters.AddWithValue("@plate_no", selectedDriver.Plate_no);
            command.Parameters.AddWithValue("@license_no", selectedDriver.License_no);


            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                if (Convert.ToInt32(reader.GetString(0)) > 0)
                {
                    closeConnection(connection);
                    return true;

                }
                closeConnection(connection);
                return false;
            }


            closeConnection(connection);
            return false;
        }


        public void saveRacer(DriverDetailsBean driverBean)
        {
            MySqlConnection connection = getConnection();

            MySqlCommand cmdDatabase;

            

                if (isDriverExist(driverBean))
                {

                    cmdDatabase = new MySqlCommand(SQLConstants.UPDATE_RACER, connection);
                }
                else
                {

                    cmdDatabase = new MySqlCommand(SQLConstants.INSERT_RACER, connection);
                }




                cmdDatabase.Parameters.AddWithValue("@team_id", driverBean.Team_id);
                cmdDatabase.Parameters.AddWithValue("@name", driverBean.Name);
                cmdDatabase.Parameters.AddWithValue("@email", driverBean.Email);
                cmdDatabase.Parameters.AddWithValue("@contact", driverBean.Contact_no);
                cmdDatabase.Parameters.AddWithValue("@address", driverBean.Address);
                cmdDatabase.Parameters.AddWithValue("@gender", driverBean.Gender);
                cmdDatabase.Parameters.AddWithValue("@birthdate", driverBean.Birthdate);
                cmdDatabase.Parameters.AddWithValue("@age", driverBean.Age);
                cmdDatabase.Parameters.AddWithValue("@vehicle_model", driverBean.Vehicle_model);
                cmdDatabase.Parameters.AddWithValue("@plate_no", driverBean.Plate_no);
                cmdDatabase.Parameters.AddWithValue("@license_no", driverBean.License_no);


                connection.Open();
                cmdDatabase.ExecuteNonQuery();
                closeConnection(connection);
            
        }

        public void removeRacer(DriverDetailsBean driverBean)
        {
            MySqlConnection con = getConnection();



            con.Open();
            MySqlCommand command = new MySqlCommand(SQLConstants.REMOVE_RACER + SQLConstants.REMOVE_RACER_IN_RACE, con);

            command.Parameters.AddWithValue("@email", driverBean.Email);
            command.Parameters.AddWithValue("@plate_no", driverBean.Plate_no);
            command.Parameters.AddWithValue("@license_no", driverBean.License_no);
            command.Parameters.AddWithValue("@driver_id", driverBean.Driver_Id);

            command.ExecuteScalar();
            closeConnection(con);
        }

        /* Connections */
        private MySqlConnection getConnection()
        {
            MySqlConnection conn = new MySqlConnection(SQLConstants.DBCONNECTION);
            return conn;
        }

        private void closeConnection(MySqlConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
