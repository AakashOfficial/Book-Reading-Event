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

            db.events.Add(ev);
            return result;
        }

    }
}