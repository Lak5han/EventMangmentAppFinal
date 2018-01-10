using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EventDetail
    {
        public int EventDetailID { get; set; }
        public string EventName { get; set; }
        public int CollageID { get; set; }
        public string EventDescription { get; set; }
        public Nullable<DateTime> EventDate { get; set; }
        public bool EventType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual Collage Collage { get; set; }
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
        public virtual ICollection<EventRound> EventRounds { get; set; }
    }
}
