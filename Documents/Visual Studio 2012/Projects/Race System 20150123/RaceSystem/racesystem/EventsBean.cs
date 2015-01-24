using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    public class EventsBean
    {
        Dictionary<RaceClass, List<RaceSession>> eventsRaceClass;
        List<RaceClass> raceClassList;


        public EventsBean()
        {

        }

        public EventsBean(Dictionary<RaceClass, List<RaceSession>> eventsRaceClass, List<RaceClass> raceClassList)
        {
            this.eventsRaceClass = eventsRaceClass;
            this.raceClassList = raceClassList;


        }

        public Dictionary<RaceClass, List<RaceSession>> EventsRaceClass
        {
            get
            {
                return this.eventsRaceClass;
            }

            set
            {
                this.eventsRaceClass = value;

            }


        }

        public List<RaceClass> RaceClassLists
        {
            get
            {
                return this.raceClassList;
            }
            set
            {
                this.raceClassList = value;

            }
        }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string Place { get; set; }


    }
}
