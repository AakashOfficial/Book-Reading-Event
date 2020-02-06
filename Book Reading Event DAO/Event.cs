using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Reading_Event_DAO
{
    class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string EventOtherDetails { get; set; }

        [Required]
        public string EventLocation { get; set; }

        [Required]
        public string EventDuration { get; set; }

        [Required]
        public int EventType { get; set; }

        public string EventDate { get; set; }

        public string EventStartTime { get; set; }

        public int EventActive { get; set; }

    }
}