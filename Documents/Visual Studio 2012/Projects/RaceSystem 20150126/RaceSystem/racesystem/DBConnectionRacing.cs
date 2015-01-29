using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    public class DBConnectionRacing
    {
        /* Get Racers */
        public AsyncObservableCollection<RacersBean> selectRacers(int classId,int sessionId)
        {
            //Create a list to store the result
            AsyncObservableCollection<RacersBean> racers = new AsyncObservableCollection<RacersBean>();
            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACERS, con);
            command.Parameters.AddWithValue("@class_id", classId);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader;

            con.Open();
            try
            {
                dataReader = command.ExecuteReader();
                Console.WriteLine(SQLConstants.SELECT_RACERS);
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetString("name"));
                    racers.Add(new RacersBean()
                    {
                        rfidTag = (string)dataReader["rfid_tag_no"],
                        rfidNo = (int)dataReader["rfid_no"],
                        racerName = (string)dataReader["name"],
                        sessionId = sessionId,
                        bestLapSpeed = 0.00,
                        lapNumber = 0,
                        lapSpeed = 0.00,
                        totalTime = 0.00,
                        positionNumber = 0
                    });
                    //racers.Add(MapToClass<RacersBean>(dataReader));
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //close connection
                con.Close();
            }
            //return list to be displayed
            return racers;
        }


        /* Get Race Description */
        public Dictionary<String, Object> getRaceDescription(int sessionId)
        {
            //Create a list to store the result
            Dictionary<String, Object> raceDesc = new Dictionary<String, Object>();
            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACE_DESC, con);
            command.Parameters.AddWithValue("@session_id", sessionId);

            //Create a data reader and Execute the command
            MySqlDataReader dataReader;

            con.Open();
            try
            {
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    raceDesc.Add("EventName", (string)dataReader["event_name"]);
                    raceDesc.Add("ClassName", (string)dataReader["class_name"]);
                    raceDesc.Add("SessionName", (string)dataReader["session_name"]);
                    raceDesc.Add("Time", dataReader["time"]);
                    raceDesc.Add("Distance", dataReader["distance"]);
                    raceDesc.Add("LapNumber", dataReader["lap_number"]);
                    //racers.Add(MapToClass<RacersBean>(dataReader));
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                //close connection
                con.Close();
            }
            //return list to be displayed
            return raceDesc;
        }

        /* Insert Lap Record */
        public void recordLapDetails(RacersBean lapRecord)
        {
            MySqlConnection conn = getConnection();
            MySqlCommand comm = new MySqlCommand(SQLConstants.INSERT_RACER_LAP_INFO, conn);
            comm.Parameters.AddWithValue("@session_id", lapRecord.sessionId);
            comm.Parameters.AddWithValue("@lap_number", lapRecord.lapNumber);
            comm.Parameters.AddWithValue("@rfid_no", lapRecord.rfidNo);
            comm.Parameters.AddWithValue("@lap_time", lapRecord.lapTime);
            comm.Parameters.AddWithValue("@total_time", lapRecord.totalTime);
            comm.Parameters.AddWithValue("@best_lap_time", lapRecord.bestLapTime);
            comm.Parameters.AddWithValue("@position", lapRecord.positionNumber);
            comm.Parameters.AddWithValue("@lap_speed", lapRecord.lapSpeed);
            comm.Parameters.AddWithValue("@best_lap_speed", lapRecord.bestLapSpeed);
            conn.Open();
            MySqlDataReader dataReader = comm.ExecuteReader();

            closeConnection(conn);
        }


        public void resetRace(String sessionId)
        {
            MySqlConnection con = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.RESET_RACE, con);
            command.Parameters.AddWithValue("@session_id", sessionId);
            con.Open();
            command.ExecuteScalar();
            closeConnection(con);
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
