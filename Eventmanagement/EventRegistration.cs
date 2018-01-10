using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EventRegistration
    {
        public int EventRegistrationID { get; set; }
        public int UserID { get; set; }
        public int EventDetailsID { get; set; }
        public bool UserAttendance { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual EventDetail EventDetail { get; set; }
        public virtual User User { get; set; }
    }
}
