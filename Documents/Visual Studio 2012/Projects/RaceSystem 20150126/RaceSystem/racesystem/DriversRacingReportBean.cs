using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    public class DriversRacingReportBean
    {
        public string EventName { get; set; }

        public string ClassName { get; set; }

        public string SessionName { get; set; }

        public string RFIDTag { get; set; }

        public string RacerName { get; set; }

        public int LapNumber { get; set; }

        public double LapTime { get; set; }

        public double BestLapTime { get; set; }

        public int Position { get; set; }

        public double LapSpeed { get; set; }

        public float BestLapSpeed { get; set; }
    }
}
