using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagmentWeb.Models
{
    public class EventDetailModel
    {
        public int EventDetailID { get; set; }
        [Required(ErrorMessage = "You must provide Event Name")]
        public string EventName { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int CollageID { get; set; }
        [Required(ErrorMessage = "Please provide some details of the event")]
        public string EventDescription { get; set; }
        public Nullable<DateTime> EventDate { get; set; }
        public bool EventType { get; set; }
    }
}