using Book_Reading_Event_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_BL
{
    public class EventOperations
    {
        bool result = false;
        private BookReadingContext db;
        public EventOperations()
        {
            db = new BookReadingContext();
        }

        public Boolean addEvents(Event ev) {
            if (ev == null) {
                return false;
            }

            if (ev.EventDate == null || ev.EventDescription == null || ev.EventLocation == null ||
                ev.EventName == null || ev.EventOtherDetails == null || ev.EventStartTime == null ) {
                return false;
            }

            // Console.WriteLine(ev.EventName);
            // Console.WriteLine(ev.EventLocation);
            // return true;
            db.events.Add(ev);
            db.SaveChanges();
            // ModelState.Clear();
            return result;
        }



    }
}