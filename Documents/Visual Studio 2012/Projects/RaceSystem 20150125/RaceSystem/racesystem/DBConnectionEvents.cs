using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RaceSystem
{
    class DBConnectionEvents
    {
        // private string connection = "datasource=localhost;port=3306;username=root;password=root";
        // private string queryEvents = "select * from racing.race_events";
        // private string queryRaceClass = "select * from racing.event_class where event_id=@event_id";
        //private string queryRaceSession = "select * from racing.event_sessions where class_id=@class_id";


        //insert event
        // private string insertEventQuery = "insert into racing.race_events (event_name,place) values (@event_name,@place); select last_insert_id();";
        // private string insertRaceClassQuery = "insert into racing.event_class (event_id,class_name,description) values(@event_id,@class_name,@description);select last_insert_id();";
        // private string insertRaceSessionQuery = "insert into racing.event_sessions (session_name,race_type,date,class_id,event_id) values(@session_name,@race_type,@date,@class_id,@event_id)";

        //delete event
        // private string deleteEventQuery = "delete from racing.race_events where event_id=@event_id;";
        //private string deleteClassQuery = "delete from racing.event_class where event_id=@event_id;";
        // private string deleteSessionQuery = "delete from racing.event_sessions where event_id=@event_id;";
        // private string deleterDriverEvent = "delete from racing.event_drivers where event_id=@event_id;";


        // private string queryOneEvent = "select count(*) as no from racing.race_events where event_id=@event_id";

        public void deleteEvent()
        {

        }

        /*
        * Inserting All events
        * */


        public void insertEvent(string eventName, string eventPlace, Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList)
        {
            MySqlConnection con = getConnection();
            MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.INSERT_EVENT, con);
            mysqlCommand.Parameters.AddWithValue("@event_name", eventName);
            mysqlCommand.Parameters.AddWithValue("@place", eventPlace);

            con.Open();
            int eventId = Convert.ToInt32(mysqlCommand.ExecuteScalar());
            closeConnection(con);



            insertRaceClass(raceClassWithSessionList, eventId);


        }


        private void insertRaceClass(Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList, int eventId)
        {
            MySqlConnection con = getConnection();



            foreach (KeyValuePair<RaceClass, List<RaceSession>> key in raceClassWithSessionList)
            {
                RaceClass rc = key.Key;
                MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.INSERT_RACECLASS, con);
                mysqlCommand.Parameters.AddWithValue("@event_id", eventId);
                mysqlCommand.Parameters.AddWithValue("@class_name", rc.Name);
                mysqlCommand.Parameters.AddWithValue("@description", rc.Description);
                con.Open();
                int id = Convert.ToInt32(mysqlCommand.ExecuteScalar());
                closeConnection(con);


                foreach (RaceSession rs in key.Value)
                {
                    mysqlCommand = new MySqlCommand(SQLConstants.INSERT_RACESESSION, con);
                    mysqlCommand.Parameters.AddWithValue("@session_name", rs.Name);
                    mysqlCommand.Parameters.AddWithValue("@race_type", rs.Type);
                    mysqlCommand.Parameters.AddWithValue("@date", rs.Date);
                    mysqlCommand.Parameters.AddWithValue("@class_id", id);
                    mysqlCommand.Parameters.AddWithValue("@event_id", eventId);
                    mysqlCommand.Parameters.AddWithValue("@distance", rs.Distance);
                    mysqlCommand.Parameters.AddWithValue("@lap_number", rs.LapNumber);
                    mysqlCommand.Parameters.AddWithValue("@time", rs.Time);
                    mysqlCommand.Parameters.AddWithValue("@schedule_time", rs.SchedTime);

                    con.Open();
                    mysqlCommand.ExecuteNonQuery();
                    closeConnection(con);
                }


            }



        }


        public void deleteEvent(List<EventsBean> eventsList)
        {
            MySqlConnection con = getConnection();

            foreach (EventsBean events in eventsList)
            {
                string query = SQLConstants.DELETE_EVENT + SQLConstants.DELETE_RACECLASS + SQLConstants.DELETE_RACESESSION + SQLConstants.DELETE_EVENT_RACER;
                Console.WriteLine(query);
                MySqlCommand mysqlCommand = new MySqlCommand(query, con);
                mysqlCommand.Parameters.AddWithValue("@event_id", events.EventId);
                con.Open();
                mysqlCommand.ExecuteScalar();
                closeConnection(con);
            }
        }

        /*End of Inserting all events
         * 
         */

        /*
         * Selecting All events
         * */
        public List<EventsBean> selectEvent()
        {
            List<EventsBean> eventsList = new List<EventsBean>();

            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_EVENTS, con);
            con.Open();
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                EventsBean events = new EventsBean();
                events.EventId = Convert.ToString(dataReader["event_id"]);
                events.EventName = (string)dataReader["event_name"];
                events.Place = (string)dataReader["place"];
                eventsList.Add(events);
            }

            con.Close();

            for (int i = 0; i < eventsList.Count(); i++)
            {
                EventsBean dummyEvent = eventsList.ElementAt(i);
                dummyEvent.RaceClassLists = selectRaceClass(dummyEvent.EventId);


            }

            for (int i = 0; i < eventsList.Count(); i++)
            {
                EventsBean dummyEvent = eventsList.ElementAt(i);
                List<RaceClass> dummyRaceClassList = dummyEvent.RaceClassLists;
                Dictionary<RaceClass, List<RaceSession>> test = new Dictionary<RaceClass, List<RaceSession>>();
                for (int j = 0; j < dummyRaceClassList.Count(); j++)
                {
                    RaceClass rc = dummyRaceClassList.ElementAt(j);
                    List<RaceSession> rs_list = selectRaceSession(rc.ClassId);

                    test.Add(rc, rs_list);

                }
                dummyEvent.EventsRaceClass = test;

            }


            return eventsList;
        }

        private List<RaceClass> selectRaceClass(string param)
        {
            List<RaceClass> raceClassList = new List<RaceClass>();
            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACECLASS, con);
            command.Parameters.AddWithValue("@event_id", param);
            con.Open();
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                RaceClass rc = new RaceClass();
                rc.ClassId = Convert.ToString(dataReader["class_id"]);
                rc.Description = (string)dataReader["description"];
                rc.Name = (string)dataReader["class_name"];

                raceClassList.Add(rc);
            }
            con.Close();

            return raceClassList;
        }

        public List<RaceSession> selectRaceSession(string param)
        {
            List<RaceSession> raceSessionList = new List<RaceSession>();
            MySqlConnection con = getConnection();
            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACESESSION, con);
            command.Parameters.AddWithValue("@class_id", param);
            con.Open();
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                RaceSession rs = new RaceSession();
                rs.Name = (string)dataReader["session_name"];
                rs.Date = Convert.ToString(dataReader["date"]);
                rs.Type = (string)dataReader["race_type"];
                rs.SessionId = Convert.ToString(dataReader["session_id"]);
                rs.Distance = (int)dataReader["distance"];
                rs.LapNumber = (int)dataReader["lap_number"];
                rs.Time = (int)dataReader["time"];
                rs.SchedTime = (string)dataReader["schedule_time"];

                // kenneth
                rs.EventName = (string)dataReader["event_name"];
                rs.ClassName = (string)dataReader["class_name"];
                rs.Place = (string)dataReader["place"];
                Console.WriteLine(dataReader["description"]);
                if (dataReader["description"] == DBNull.Value)
                    rs.Description = "";
                else
                    rs.Description = Convert.ToString(dataReader["description"]);
                //rs.Description = dataReader["description"] == null ? "" : (string)dataReader["description"];
                raceSessionList.Add(rs);
            }
            con.Close();

            return raceSessionList;
        }


        /* End of Selecting Events
         * 
         * */

        /* Todays Event List */
        public List<RaceSession> getEventToday()
        {

            List<RaceSession> eventToday = new List<RaceSession>();
            //local variable
            // string queryString = "SELECT *  FROM  racing.drivers";
            // string constring = "datasource =localhost;port=3306;username=root;password=root";
            MySqlConnection connection = getConnection();

            MySqlCommand command = new MySqlCommand(SQLConstants.SELECT_RACE_SESSIONS_TODAY, connection);
            connection.Open();
            MySqlDataReader dataReader = command.ExecuteReader();
            try
            {
                while (dataReader.Read())
                {
                    RaceSession rs = new RaceSession();
                    rs.Date = Convert.ToString(dataReader["date"]);
                    rs.SessionId = Convert.ToString(dataReader["session_id"]);
                    rs.Name = (string)dataReader["session_name"];
                    rs.ClassId = Convert.ToInt32(dataReader["class_id"]);
                    rs.SchedTime = (string)dataReader["schedule_time"];
                    eventToday.Add(rs);
                }
                return eventToday;
            }
            finally
            {
                // Always call Close when done reading.
                dataReader.Close();
                closeConnection(connection);
            }

        }


        public void getEvent()
        {

            List<EventsBean> eventsList = selectEvent();


        }


        public Boolean isExist(EventsBean events)
        {

            MySqlConnection con = getConnection();
            MySqlCommand cmd = new MySqlCommand(SQLConstants.SELECT_ONE_EVENT, con);
            cmd.Parameters.AddWithValue("@event_id", events.EventId);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i = Convert.ToInt32(reader["no"]);
            }
            con.Close();

            if (i == 0)
                return false;

            return true;

        }

        /* Update Events */
        public void updateEvent(string eventName, string eventPlace, string event_id, Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList)
        {
            MySqlConnection con = getConnection();
            MySqlCommand mysqlCommand = new MySqlCommand(SQLConstants.UPDATE_EVENT, con);
            mysqlCommand.Parameters.AddWithValue("@event_name", eventName);
            mysqlCommand.Parameters.AddWithValue("@place", eventPlace);
            mysqlCommand.Parameters.AddWithValue("@event_id", event_id);

            con.Open();
            mysqlCommand.ExecuteNonQuery();
            closeConnection(con);

            foreach (KeyValuePair<RaceClass, List<RaceSession>> entry in raceClassWithSessionList)
            {
                Console.WriteLine(entry.Key);
                // do something with entry.Value or entry.Key
            }

            updateRaceClass(raceClassWithSessionList, event_id);
        }


        private void updateRaceClass(Dictionary<RaceClass, List<RaceSession>> raceClassWithSessionList, string eventId)
        {
            MySqlConnection con = getConnection();



            foreach (KeyValuePair<RaceClass, List<RaceSession>> key in raceClassWithSessionList)
            {
                RaceClass rc = key.Key;
                int classId = rc.ClassId != null ? Convert.ToInt32(rc.ClassId) : 0;

                MySqlCommand mysqlCommand = new MySqlCommand(rc.ClassId != null ? SQLConstants.UPDATE_RACECLASS : SQLConstants.INSERT_RACECLASS, con);
                mysqlCommand.Parameters.AddWithValue("@event_id", eventId);
                mysqlCommand.Parameters.AddWithValue("@class_name", rc.Name);
                mysqlCommand.Parameters.AddWithValue("@description", rc.Description);
                con.Open();
                if (rc.ClassId != null)
                {
                    mysqlCommand.Parameters.AddWithValue("@class_id", classId);
                    mysqlCommand.ExecuteNonQuery();
                }
                else
                    classId = Convert.ToInt32(mysqlCommand.ExecuteScalar());
               
                closeConnection(con);

                mysqlCommand = new MySqlCommand(SQLConstants.DELETE_RACESESSION_PERCLASS, con);
                mysqlCommand.Parameters.AddWithValue("@class_id", classId);
                mysqlCommand.Parameters.AddWithValue("@event_id", eventId);

                con.Open();
                mysqlCommand.ExecuteScalar();
                closeConnection(con);

                foreach (RaceSession rs in key.Value)
                {
                    /*
                    Console.WriteLine(classId+" "+(classId != 0 && rs.SessionId != null));
                    mysqlCommand = new MySqlCommand(classId != 0 && rs.SessionId != null ? SQLConstants.UPDTE_RACESESSION : SQLConstants.INSERT_RACESESSION, con);
                    mysqlCommand.Parameters.AddWithValue("@session_name", rs.Name);
                    mysqlCommand.Parameters.AddWithValue("@race_type", rs.Type);    
                    mysqlCommand.Parameters.AddWithValue("@date", rs.Date);
                    mysqlCommand.Parameters.AddWithValue("@event_id", eventId);
                    mysqlCommand.Parameters.AddWithValue("@distance", rs.Distance);
                    mysqlCommand.Parameters.AddWithValue("@lap_number", rs.LapNumber);
                    mysqlCommand.Parameters.AddWithValue("@time", rs.Time);

                    if (classId != 0 && rs.SessionId != null)
                    {
                        mysqlCommand.Parameters.AddWithValue("@class_id", classId);
                        mysqlCommand.Parameters.AddWithValue("@session_id", rs.SessionId);
                    }
                    con.Open();
                    mysqlCommand.ExecuteNonQuery();
                    closeConnection(con);*/

                    mysqlCommand = new MySqlCommand(SQLConstants.INSERT_RACESESSION, con);
                    mysqlCommand.Parameters.AddWithValue("@session_name", rs.Name);
                    mysqlCommand.Parameters.AddWithValue("@race_type", rs.Type);
                    mysqlCommand.Parameters.AddWithValue("@date", rs.Date);
                    mysqlCommand.Parameters.AddWithValue("@class_id", classId);
                    mysqlCommand.Parameters.AddWithValue("@event_id", eventId);
                    mysqlCommand.Parameters.AddWithValue("@distance", rs.Distance);
                    mysqlCommand.Parameters.AddWithValue("@lap_number", rs.LapNumber);
                    mysqlCommand.Parameters.AddWithValue("@time", rs.Time);
                    mysqlCommand.Parameters.AddWithValue("@schedule_time", rs.SchedTime);

                    con.Open();
                    mysqlCommand.ExecuteNonQuery();
                    closeConnection(con);
                }


            }



        }

        /* Update Events */

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
