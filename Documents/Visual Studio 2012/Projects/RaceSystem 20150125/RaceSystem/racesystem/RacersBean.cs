using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RaceSystem
{
    public class RacersBean : INotifyPropertyChanged
    {
        private int session_id;
        private int rfid_no;
        private string rfid_tag;
        private string racer_name;
        private int lap_number;
        private DateTime time_of_lap;
        private double lap_time;
        private double best_lap_time;
        private int position;
        private double lap_speed;
        private double best_lap_speed;

        //[Mapping(ColumnName = "session_id")]
        public int sessionId
        {
            get { return session_id; }
            set
            {
                session_id = value;
                NotifyPropertyChanged("session_id");
            }
        }

        //[Mapping(ColumnName = "rfid_tag")]
        public string rfidTag
        {
            get { return rfid_tag; }
            set
            {
                rfid_tag = value;
                NotifyPropertyChanged("rfid_tag");
            }
        }

        //[Mapping(ColumnName = "rfid_no")]
        public int rfidNo
        {
            get { return rfid_no; }
            set
            {
                rfid_no = value;
                NotifyPropertyChanged("rfid_no");
            }
        }

        //[Mapping(ColumnName = "name")]
        public string racerName
        {
            get { return racer_name; }
            set
            {
                racer_name = value;
                NotifyPropertyChanged("racer_name");
            }
        }

        //[Mapping(ColumnName = "lap_number")]
        public int lapNumber
        {
            get { return lap_number; }
            set
            {
                lap_number = value;
                NotifyPropertyChanged("lap_number");
            }
        }

        //[Mapping(ColumnName = "time_of_lap")]
        public DateTime timeOfLap
        {
            get { return time_of_lap; }
            set
            {
                time_of_lap = value;
                NotifyPropertyChanged("time_of_lap");
            }
        }

        //[Mapping(ColumnName = "lap_time")]
        public double lapTime
        {
            get { return lap_time; }
            set
            {
                lap_time = value;
                NotifyPropertyChanged("lap_time");
            }
        }

        //[Mapping(ColumnName = "lap_time")]
        public double bestLapTime
        {
            get { return best_lap_time; }
            set
            {
                best_lap_time = value;
                NotifyPropertyChanged("best_lap_time");
            }
        }

        //[Mapping(ColumnName = "position")]
        public int positionNumber
        {
            get { return position; }
            set
            {
                position = value;
                NotifyPropertyChanged("position");
            }
        }

        //[Mapping(ColumnName = "lap_speed")]
        public double lapSpeed
        {
            get { return lap_speed; }
            set
            {
                lap_speed = value;
                NotifyPropertyChanged("lap_speed");
            }
        }

        //[Mapping(ColumnName = "best_lap_speed")]
        public double bestLapSpeed
        {
            get { return best_lap_speed; }
            set
            {
                best_lap_speed = value;
                NotifyPropertyChanged("best_lap_speed");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
