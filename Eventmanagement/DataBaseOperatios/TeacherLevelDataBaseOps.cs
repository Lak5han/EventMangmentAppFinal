using DataLayer;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmanagement.DataBaseOperatios
{    
    public class TeacherLevelDataBaseOps
    {
        private EventmanagementDbContext db = new EventmanagementDbContext();
        public List<EventRegistration> ListofEventRegistration(int id)
        {
            List<EventRegistration> EventRegistrationList = new List<EventRegistration>();
            try
            {
                EventRegistrationList = db.EventEventRegistrations.Where(c=>c.EventDetailsID == id).ToList();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }

            return EventRegistrationList;
        }
    }
}
