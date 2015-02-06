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
                    racingReport.EventName = reader["event_name"] != DBNull.Value ? (string)reader["event_name"]:"";
                    racingReport.ClassName = reader["class_name"] != DBNull.Value ? (string)reader["class_name"] : "";
                    racingReport.SessionName = reader["session_name"] != DBNull.Value ? (string)reader["session_name"] : "";
                    racingReport.RFIDTag = reader["rfid_tag_no"] != DBNull.Value ? (string)reader["rfid_tag_no"] : "";
                    racingReport.Position = reader["position"] != DBNull.Value ? (int)reader["position"] : 0;
                    racingReport.VehicleType = reader["vehicle_model"] != DBNull.Value ? (string)reader["vehicle_model"] : "";
                    racingReport.LapNumber = reader["lap_number"] != DBNull.Value ? (int)reader["lap_number"] : 0;
                    racingReport.TotalTime = reader["total_time"] != DBNull.Value ? (float)reader["total_time"] : 0;
                    racingReport.LapTime = reader["lap_time"] != DBNull.Value ? (float)reader["lap_time"] : 0;
                    racingReport.BestLapTime = reader["best_lap_time"] != DBNull.Value ? (float)reader["best_lap_time"] : 0;
                    racingReport.LapSpeed = reader["lap_speed"] != DBNull.Value ? (float)reader["lap_speed"] : 0;
                    racingReport.BestLapSpeed = reader["best_lap_speed"] != DBNull.Value ? (float)reader["best_lap_speed"] : 0;
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
                    racingReport.RFIDTag = reader["rfid_tag_no"] != DBNull.Value ? (string)reader["rfid_tag_no"] : "";
                    racingReport.Position = reader["position"] != DBNull.Value ? (int)reader["position"] : 0;
                    racingReport.RacerName = reader["name"] != DBNull.Value ? (string)reader["name"] : "";
                    racingReport.VehicleType = reader["vehicle_model"] != DBNull.Value ? (string)reader["vehicle_model"] : "";
                    racingReport.LapNumber = reader["lap_number"] != DBNull.Value ? (int)reader["lap_number"] : 0;
                    racingReport.TotalTime = reader["total_time"] != DBNull.Value ? (float)reader["total_time"] : 0;
                    racingReport.LapTime = reader["lap_time"] != DBNull.Value ? (float)reader["lap_time"] : 0;
                    racingReport.BestLapTime = reader["best_lap_time"] != DBNull.Value ? (float)reader["best_lap_time"] : 0;
                    racingReport.LapSpeed = reader["lap_speed"] != DBNull.Value ? (float)reader["lap_speed"] : 0;
                    racingReport.BestLapSpeed = reader["best_lap_speed"] != DBNull.Value ? (float)reader["best_lap_speed"] : 0;
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
