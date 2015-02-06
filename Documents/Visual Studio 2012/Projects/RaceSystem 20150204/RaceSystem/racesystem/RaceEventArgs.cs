using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    public class RaceEventArgs : System.EventArgs
    {
        private string raceName;
        private string raceDescription;
        private string date;
        private string distance;
        private string lapNumber;
        private string time;
        private string schedTime;


        public RaceEventArgs(string raceName, string raceDescription)
        {
            this.raceName = raceName;
            this.raceDescription = raceDescription;
        }

        public RaceEventArgs(string raceName, string raceDescription, string date)
        {
            this.raceName = raceName;
            this.raceDescription = raceDescription;
            this.date = date;
        }

        public RaceEventArgs(string raceName, string raceDescription, string date, string distance)
        {
            this.raceName = raceName;
            this.raceDescription = raceDescription;
            this.date = date;
            this.distance = distance;
        }
        public RaceEventArgs(string raceName, string raceDescription, string date, string distance, string lapNumber, string time)
        {
            this.raceName = raceName;
            this.raceDescription = raceDescription;
            this.date = date;
            this.distance = distance;
            this.lapNumber = lapNumber;
            this.time = time;
        }
        public RaceEventArgs(string raceName, string raceDescription, string date, string distance, string lapNumber, string time,string schedTime)
        {
            this.raceName = raceName;
            this.raceDescription = raceDescription;
            this.date = date;
            this.distance = distance;
            this.lapNumber = lapNumber;
            this.time = time;
            this.schedTime = schedTime;
        }


        public string RaceName
        {
            get
            {
                return this.raceName;
            }

        }

        public string RaceDescription
        {
            get
            {
                return this.raceDescription;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }
        }

        public string Distance
        {
            get
            {
                return this.distance;
            }
        }

        public string LapNumber
        {
            get
            {
                return this.lapNumber;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
        }

        public string SchedTime
        {
            get
            {
                return this.schedTime;
            }

        }

    }
}
