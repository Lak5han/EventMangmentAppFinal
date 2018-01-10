using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessModel
{
    public class EventDetailBusinessModel
    {
        public int EventDetailID { get; set; }
        public string EventName { get; set; }
        public int CollageID { get; set; }
        public string EventDescription { get; set; }
        public Nullable<DateTime> EventDate { get; set; }
        public bool EventType { get; set; }
    }
}
