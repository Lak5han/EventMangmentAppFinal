using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EventManagmentWeb.Models
{
    public class EventRegistrationmarkModel
    {
        public int EventRegistrationID { get; set; }

        public int EventDetailID { get; set; }

        [DisplayName("Event Name")]
        public string EventName { get; set; }

        public int UserID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Check Attendance")]
        public bool UserAttendance { get; set; }
    }
}