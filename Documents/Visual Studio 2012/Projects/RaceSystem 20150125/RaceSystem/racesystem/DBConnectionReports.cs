using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionReports
    {

        /* Reports */
        public List<DriversRacingReportBean> getDriverRacingDetails(String driverId)
        {

            List<DriversRacingReportBean> beanList = new List<DriversRacingReportBean>();//local variable
            // string queryString = "SELECT *  FROM  racing.drivers";
            // string constring = "datasource =localhost;port=3306;username=root;password=root";
            MySqlConnection connection = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_DRIVER_RACING_DETAILS, connection);
            Console.WriteLine(driverId+" "+SQLConstants.SELECT_DRIVER_RACING_DETAILS);
            command.Parameters.AddWithValue("@driver_id", driverId);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    DriversRacingReportBean racingReport = new DriversRacingReportBean();
                    racingReport.EventName = (string)reader["event_name"];
                    racingReport.ClassName = (string)reader["class_name"];
                    racingReport.SessionName = (string)reader["session_name"];
                    racingReport.RFIDTag = (string)reader["rfid_tag_no"];
                    racingReport.Position = (int)reader["position"];
                    racingReport.LapNumber = (int)reader["lap_number"];
                    racingReport.LapTime = (float)reader["lap_time"];
                    racingReport.BestLapTime = (float)reader["best_lap_time"];
                    racingReport.LapSpeed = (float)reader["lap_speed"];
                    racingReport.BestLapSpeed = (float)reader["best_lap_speed"];
                    beanList.Add(racingReport);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            return beanList;

        }

        public List<DriversRacingReportBean> getEventRacingDetails(String sessionId)
        {

            List<DriversRacingReportBean> beanList = new List<DriversRacingReportBean>();//local variable
            // string queryString = "SELECT *  FROM  racing.drivers";
            // string constring = "datasource =localhost;port=3306;username=root;password=root";
            MySqlConnection connection = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_EVENT_RACING_DETAILS, connection);
            Console.WriteLine(sessionId + " " + SQLConstants.SELECT_DRIVER_RACING_DETAILS);
            command.Parameters.AddWithValue("@session_id", sessionId);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    DriversRacingReportBean racingReport = new DriversRacingReportBean();
                    racingReport.RFIDTag = (string)reader["rfid_tag_no"];
                    racingReport.Position = (int)reader["position"];
                    racingReport.RacerName = (string)reader["name"];
                    racingReport.LapNumber = (int)reader["lap_number"];
                    racingReport.LapTime = (float)reader["lap_time"];
                    racingReport.BestLapTime = (float)reader["best_lap_time"];
                    racingReport.LapSpeed = (float)reader["lap_speed"];
                    racingReport.BestLapSpeed = (float)reader["best_lap_speed"];
                    beanList.Add(racingReport);
                }
            }
            finally
            {
                // Always call Close when done reading.
                reader.Close();
            }
            return beanList;

        }
        /* END Report */



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
