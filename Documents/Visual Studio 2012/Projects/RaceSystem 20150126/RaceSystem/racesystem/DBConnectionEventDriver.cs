using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionEventDriver
    {
       // private string connection = "datasource=localhost;port=3306;username=root;password=root";

       // private string getAllRegisteredDriver = "select * from racing.event_drivers ev join racing.drivers d on d.driver_id = ev.driver_id where ev.session_id = @session_id;";
       // private string getAllDriverNotRegistered = "select * from racing.drivers d where not exists (select * from racing.event_drivers ev where d.driver_id = ev.driver_id and ev.session_id = @session_id)";


        //private string getAllRfidNotRegistered = "select * from racing.rfid_list rd where not exists (select * from racing.event_drivers ev where ev.rfid_no = rd.rfid_tag_no)";
        //private string insertdriver = "insert into racing.event_drivers values(@event_id,@session_id,@driver_id, @rfid_no, @class_id);";
       // private string removeDriver = "delete from racing.event_drivers where driver_id = @driver_id and session_id = @session_id";


        public List<DriverDetailsBean> getRegisteredDriver(string session_id)
        {
            List<DriverDetailsBean> driverDetailsBeanList = new List<DriverDetailsBean>();

            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.SELECT_ALL_REGISTERED_RACER, conn);
            comm.Parameters.AddWithValue("@session_id",session_id);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();
            while(dataReader.Read())
            {
                DriverDetailsBean ddb = new DriverDetailsBean();
                ddb.Name = (string)dataReader["Name"];
                ddb.Rfid_No = (string)dataReader["rfid_no"];
                ddb.Team_id = (string)dataReader["team_id"];
                ddb.Vehicle_model = (string)dataReader["vehicle_model"];
                ddb.Driver_Id = (string)dataReader["driver_id"];
                ddb.Session_Id = (string)dataReader["session_id"];
                ddb.Class_Id = (string)dataReader["class_id"];

                driverDetailsBeanList.Add(ddb);
            }
            closeConnection(conn);


            return driverDetailsBeanList;
        }

        public List<DriverDetailsBean> getRegisteredDriverUsingClassId(string class_id)
        {
            List<DriverDetailsBean> driverDetailsBeanList = new List<DriverDetailsBean>();

            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.SELECT_ALL_REGISTERED_RACER_USING_CLASS_ID, conn);
            comm.Parameters.AddWithValue("@class_id", class_id);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();
            while (dataReader.Read())
            {
                DriverDetailsBean ddb = new DriverDetailsBean();
                ddb.Name = (string)dataReader["Name"];
                ddb.Rfid_No = (string)dataReader["rfid_no"];
                ddb.Team_id = (string)dataReader["team_id"];
                ddb.Vehicle_model = (string)dataReader["vehicle_model"];
                ddb.Driver_Id = (string)dataReader["driver_id"];
                ddb.Session_Id = (string)dataReader["session_id"];
                ddb.Class_Id = (string)dataReader["class_id"];

                driverDetailsBeanList.Add(ddb);
            }
            closeConnection(conn);


            return driverDetailsBeanList;
        }


        public List<DriverDetailsBean> getNotRegisteredDrivers(string session_id)
        {
            List<DriverDetailsBean> driverDetailsBeanList = new List<DriverDetailsBean>();

            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.SELECT_ALL_NOT_REGISTERED_RACER, conn);
            comm.Parameters.AddWithValue("@session_id", session_id);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();
            while (dataReader.Read())
            {
                DriverDetailsBean ddb = new DriverDetailsBean();
                ddb.Name = (string)dataReader["Name"];
                ddb.Team_id = (string)dataReader["team_id"];
                ddb.Vehicle_model = (string)dataReader["vehicle_model"];
                ddb.Driver_Id = Convert.ToString(dataReader["driver_id"]);

                driverDetailsBeanList.Add(ddb);
            }
            closeConnection(conn);

            return driverDetailsBeanList;
        }

        public List<DriverDetailsBean> getNotRegisteredDriversUsingClassId(string class_id)
        {
            List<DriverDetailsBean> driverDetailsBeanList = new List<DriverDetailsBean>();

            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.SELECT_ALL_NOT_REGISTERED_RACER_USING_CLASS_ID, conn);
            comm.Parameters.AddWithValue("@class_id", class_id);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();
            while (dataReader.Read())
            {
                DriverDetailsBean ddb = new DriverDetailsBean();
                ddb.Name = (string)dataReader["Name"];
                ddb.Team_id = (string)dataReader["team_id"];
                ddb.Vehicle_model = (string)dataReader["vehicle_model"];
                ddb.Driver_Id = Convert.ToString(dataReader["driver_id"]);

                driverDetailsBeanList.Add(ddb);
            }
            closeConnection(conn);

            return driverDetailsBeanList;
        }

        public List<RfidBean> getAllRfidNotRegisteredList()
        {
            List<RfidBean> rfidBeanList = new List<RfidBean>();

            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.SELECT_ALL_RFID_NOT_REGISTERED, conn);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();
            while (dataReader.Read())
            {
                RfidBean rfid = new RfidBean();
                rfid.Rfid_No = dataReader["rfid_no"].ToString();
                rfidBeanList.Add(rfid);
            }
            closeConnection(conn);

            return rfidBeanList;
        }

        public void registerDriver(Dictionary<string,string> map)
        {
            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.INSERT_EVENT_RACER, conn);
            comm.Parameters.AddWithValue("@event_id", map["event_id"]);
            comm.Parameters.AddWithValue("@session_id", map["session_id"]);
            comm.Parameters.AddWithValue("@driver_id", map["driver_id"]);
            comm.Parameters.AddWithValue("@rfid_no", map["rfid_no"]);
            comm.Parameters.AddWithValue("@class_id", map["class_id"]);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();

            closeConnection(conn);

        }

        public void registerDriverUsingClassId(Dictionary<string, string> map)
        {
            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.INSERT_EVENT_RACER_USING_CLASS_ID, conn);
            comm.Parameters.AddWithValue("@event_id", map["event_id"]);
            comm.Parameters.AddWithValue("@driver_id", map["driver_id"]);
            comm.Parameters.AddWithValue("@rfid_no", map["rfid_no"]);
            comm.Parameters.AddWithValue("@class_id", map["class_id"]);
            comm.Parameters.AddWithValue("@vehicle_model", map["vehicle_id"]);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();

            closeConnection(conn);

        }




        public void removeDrivers(List<DriverDetailsBean> list)
        {
            MySqlConnection con = getConnection();

            foreach (DriverDetailsBean ddb in list)
            {
                MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.REMOVE_EVENT_RACER, con);
                mysqlCommand.Parameters.AddWithValue("@driver_id", ddb.Driver_Id);
                mysqlCommand.Parameters.AddWithValue("@session_id", ddb.Session_Id);
                con.Open();
                mysqlCommand.ExecuteScalar();
                closeConnection(con);
            }
        }

        public void removeDriversUsingClassId(List<DriverDetailsBean> list)
        {
            MySqlConnection con = getConnection();

            foreach (DriverDetailsBean ddb in list)
            {
                MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.REMOVE_EVENT_RACER_USING_CLASS_ID, con);
                mysqlCommand.Parameters.AddWithValue("@driver_id", ddb.Driver_Id);
                mysqlCommand.Parameters.AddWithValue("@class_id", ddb.Class_Id);
                con.Open();
                mysqlCommand.ExecuteScalar();
                closeConnection(con);
            }
        }








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
