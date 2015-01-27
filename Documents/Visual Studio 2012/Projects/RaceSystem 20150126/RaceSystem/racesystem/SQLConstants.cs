using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    class SQLConstants
    {

        public static string DBCONNECTION = "datasource=localhost;port=3306;database=racing_system;username=root;password=";
        /* Home Window */
        public static string SELECT_RACE_SESSIONS_TODAY = "select * from event_sessions where date = CURRENT_DATE ORDER BY date";
        /* END Home WIndow */

        /* Settings */
        public static string SELECT_RFID_ADDRESS = "select rfid_address from appl_settings";
        public static string SELECT_RFID_COMPORT = "select rfid_comport from appl_settings";
        public static string UPDATE_SETTINGS_ADDRESS = "update appl_settings set rfid_address = @rfid_address";
        public static string UPDATE_SETTINGS_COMPORT = "update appl_settings set rfid_comport = @rfid_comport";
        /* END Settings */

        /* Racing Window */
        public static string SELECT_RACERS = "Select rfid_tag_no, rl.rfid_no, name from event_drivers ed " +
                                                "LEFT OUTER JOIN race_events re ON ed.event_id = re.event_id " +
                                                "LEFT OUTER JOIN event_class ec ON ed.class_id = ec.class_id " +
                                                //"LEFT OUTER JOIN event_sessions es ON ed.session_id = es.session_id " +
                                                "LEFT OUTER JOIN rfid_list rl ON ed.rfid_no = rl.rfid_no " +
                                                "LEFT OUTER JOIN drivers d ON ed.driver_id = d.driver_id where ed.class_id = @class_id";
        public static string RESET_RACE = "Delete from lap_records where session_id = @session_id";
        public static string SELECT_RACE_DESC = "SELECT event_name, class_name, session_name, lap_number, distance, time FROM event_sessions es " +
                                                "LEFT OUTER JOIN race_events re ON es.event_id = re.event_id " +
                                                "LEFT OUTER JOIN event_class ec ON ec.class_id = es.class_id " +
                                                "where es.session_id = @session_id";
        public static string INSERT_RACER_LAP_INFO = "insert into lap_records values(null, @session_id,@lap_number, @rfid_no, @lap_time, @best_lap_time, @position,@lap_speed,@best_lap_speed)";
        /* END Racing Window */

        /*START Manage Events  */
        //Get Events
        public static string SELECT_EVENTS = "select * from race_events";
        public static string SELECT_RACECLASS = "select * from event_class where event_id=@event_id";
        public static string SELECT_RACESESSION = "select * from event_sessions es  " +
                                                  "LEFT OUTER JOIN race_events re ON re.event_id = es.event_id " +
                                                  "LEFT OUTER JOIN event_class ec ON ec.class_id = es.class_id " +
                                                  "where es.class_id LIKE @class_id";
        public static string SELECT_ONE_EVENT = "select count(*) as no from race_events where event_id=@event_id";

        //insert event
        public static string INSERT_EVENT = "insert into race_events (event_name,place) values (@event_name,@place); select last_insert_id();";
        public static string INSERT_RACECLASS = "insert into event_class (event_id,class_name,description) values(@event_id,@class_name,@description);select last_insert_id();";
        public static string INSERT_RACESESSION = "insert into event_sessions (session_name,race_type,date,class_id,event_id,distance,time,lap_number,schedule_time) values(@session_name,@race_type,@date,@class_id,@event_id, @distance,@time,@lap_number,@schedule_time)";

        //delete event
        public static string DELETE_EVENT = "delete from race_events where event_id=@event_id;";
        public static string DELETE_RACECLASS = "delete from event_class where event_id=@event_id;";
        public static string DELETE_RACESESSION = "delete from event_sessions where event_id=@event_id;";
        public static string DELETE_RACESESSION_PERCLASS = "delete from event_sessions where event_id=@event_id AND class_id = @class_id;";
        public static string DELETE_EVENT_RACER = "delete from event_drivers where event_id=@event_id;";

        //update events
        public static string UPDATE_EVENT = "update  race_events set event_name = @event_name , place = @place where event_id = @event_id;";
        public static string UPDATE_RACECLASS = "update event_class set class_name = @class_name, description = @description where event_id = @event_id AND class_id = @class_id;";
        public static string UPDTE_RACESESSION = "update event_sessions set session_name = @session_name, race_type = @race_type ,date = @date,distance = @distance,time = @time,lap_number = @lap_number where event_id = @event_id AND session_id = @session_id;";
        /*END Manage Events  */

        /*START Manage Event Racer */

        public static string SELECT_ALL_REGISTERED_RACER = "select * from event_drivers ev join drivers d on d.driver_id = ev.driver_id where ev.session_id = @session_id;";
        public static string SELECT_ALL_NOT_REGISTERED_RACER = "select * from drivers d where not exists (select * from event_drivers ev where d.driver_id = ev.driver_id and ev.session_id = @session_id)";
        
        public static string SELECT_ALL_RFID_NOT_REGISTERED = "select * from rfid_list rd where rfid_no not in (select rfid_no from event_drivers)";
        public static string INSERT_EVENT_RACER = "insert into event_drivers values(@event_id,@session_id,@driver_id, @rfid_no, @class_id);";
        public static string REMOVE_EVENT_RACER = "delete from event_drivers where driver_id = @driver_id and session_id = @session_id";

        //Using class id
        public static string SELECT_ALL_REGISTERED_RACER_USING_CLASS_ID = "select * from event_drivers ev join drivers d on d.driver_id = ev.driver_id where ev.class_id = @class_id;";
        public static string SELECT_ALL_NOT_REGISTERED_RACER_USING_CLASS_ID = "select * from drivers d where not exists (select * from event_drivers ev where d.driver_id = ev.driver_id and ev.class_id = @class_id)";


        public static string INSERT_EVENT_RACER_USING_CLASS_ID = "insert into event_drivers values(@event_id,'',@driver_id, @rfid_no, @class_id,@vehicle_model);";
        public static string REMOVE_EVENT_RACER_USING_CLASS_ID = "delete from event_drivers where driver_id = @driver_id and class_id = @class_id";
        /* END Manage Event Racer */

        /*START Manage Racer */


        public static string SELECT_RACER = "SELECT count(*) as pogi FROM  drivers WHERE email = @email and plate_no =@plate_no and license_no=@license_no";
        public static string SELECT_ALL_RACER = "SELECT *  FROM  drivers";

        public static string INSERT_RACER = "insert into drivers(team_id,name,email,contact_no,address,gender,birthdate,age,vehicle_model,plate_no,license_no) values(@team_id,@name,@email,@contact,@address,@gender,@birthdate,@age,@vehicle_model,@plate_no,@license_no);";
        public static string UPDATE_RACER = "update drivers Set team_id =@team_id, name = @name, email=@email, contact_no = @contact, address =@address, gender = @gender, birthdate = @birthdate, age =@age, vehicle_model= @vehicle_model, plate_no= @plate_no, license_no=@license_no  WHERE email = @email and plate_no =@plate_no and license_no=@license_no;";


        public static string REMOVE_RACER = "DELETE FROM drivers WHERE email = @email and plate_no =@plate_no and license_no=@license_no;";
        public static string REMOVE_RACER_IN_RACE = "delete from event_drivers where driver_id = @driver_id;";
        /*END Manage Racer */

        /* Racing */
        public static string INSERT_RACER_LAP_DETAILS = "insert into drivers(team_id,name,email,contact_no,address,gender,birthdate,age,vehicle_model,plate_no,license_no) " +
                                            "values(@team_id,@name,@email,@contact,@address,@gender,@birthdate,@age,@vehicle_model,@plate_no,@license_no);";
        /* END Racing*/


        /* Reports */
        // Driver
        public static string SELECT_DRIVER_RACING_DETAILS = "SELECT * " +//event_name, class_name, place, session_name, race_type, es.date, rfid_tag_no, name, lr.lap_number, position, lap_speed, best_lap_speed " +
                                                            "FROM event_drivers ed " +
                                                            "INNER JOIN lap_records lr ON ed.rfid_no = lr.rfid_no " +
                                                            "LEFT OUTER JOIN rfid_list rl ON lr.rfid_no = rl.rfid_no " +
                                                            "LEFT OUTER JOIN event_sessions es ON lr.session_id = es.session_id " +
                                                            "LEFT OUTER JOIN race_events re ON es.event_id = re.event_id " +
                                                            "LEFT OUTER JOIN event_class ec ON ec.class_id = es.class_id " +
                                                            "LEFT OUTER JOIN drivers d ON ed.driver_id = d.driver_id " +
                                                            "Where d.driver_id = @driver_id";

        // Event
        public static string SELECT_EVENT_RACING_DETAILS = "SELECT * " +//rfid_tag_no, name, lr.lap_number, position, lap_speed, best_lap_speed " +
                                                            "FROM event_drivers ed " +
                                                            "INNER JOIN lap_records lr ON ed.rfid_no = lr.rfid_no " +
                                                            "LEFT OUTER JOIN rfid_list rl ON lr.rfid_no = rl.rfid_no " +
                                                            "LEFT OUTER JOIN event_sessions es ON lr.session_id = es.session_id " +
                                                            "LEFT OUTER JOIN race_events re ON es.event_id = re.event_id " +
                                                            "LEFT OUTER JOIN event_class ec ON ec.class_id = es.class_id " +
                                                            "LEFT OUTER JOIN drivers d ON ed.driver_id = d.driver_id " +
                                                            "Where es.session_id = @session_id";
        
        /*END Reports */



        /*START Manage Rfid*/
        public static string SELECT_ALL_RFID = "SELECT * FROM rfid_list;";
        public static string REMOVE_RFID = "DELETE FROM rfid_list where rfid_no = @rfid_no;";
        //public static string ADD_RFID = "insert into rfid_list (rfid_tag_no) values (@rfid_tag_no);";
        public static string ADD_RFID = "INSERT INTO rfid_list (rfid_tag_no) SELECT @rfid_tag_no FROM dual WHERE NOT EXISTS (SELECT rfid_tag_no FROM rfid_list WHERE rfid_tag_no = @rfid_tag_no);" + SELECT_ALL_RFID;

        /*END Manage Rfid*/

    }
}
