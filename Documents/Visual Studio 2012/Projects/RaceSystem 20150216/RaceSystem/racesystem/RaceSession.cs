using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    public class RaceSession
    {
        private string date;

        public string EventName { get; set; }

        public string ClassName { get; set; }

        public string Place { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string SessionId { get; set; }

        public int Distance { get; set; }

        public int LapNumber { get; set; }

        public int Time { get; set; }

        public string SchedTime { get; set; }

        public int ClassId { get; set; }

        public string EventClassSession
        {
            get
            {
                return EventName + " - " + ClassName + " - " + Name;
            }
            set
            {
                this.EventClassSession = EventName + " - " + ClassName + " - " + Name;
            }
        }

        public string Date
        {
            get
            {
                /* DateTime time = DateTime.ParseExact(date,"yyyy/M/d",null);
                 string format  = "yyyy/M/d";


                 return time.ToString(format); */

                DateTime d = Convert.ToDateTime(date);
                string format = "yyyy/MM/dd";

                date = d.ToString(format);
                return date;
            }
            set
            {
                this.date = value;

            }

        }
    }

}
