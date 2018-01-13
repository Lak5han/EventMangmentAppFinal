using DataLayer;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmanagement.DataBaseOperatios
{
    public class StudentLevelDataBaseOps
    {
        private EventmanagementDbContext db = new EventmanagementDbContext();
        public EventRegistration UserEventRegistration(EventRegistration eventRegistration)
        {
            try
            {
                db.EventEventRegistrations.Add(eventRegistration);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            
            return eventRegistration;
        }
    }
}
