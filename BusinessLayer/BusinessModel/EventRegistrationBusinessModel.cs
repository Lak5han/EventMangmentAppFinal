using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessModel
{
    public class EventRegistrationBusinessModel
    {
        public int EventRegistrationID { get; set; }
        public int UserID { get; set; }
        public int EventDetailsID { get; set; }
        public bool UserAttendance { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }
    }
}
