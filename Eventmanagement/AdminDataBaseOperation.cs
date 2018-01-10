using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AdminDataBaseOperation
    {
        private EventmanagementDbContext db = new EventmanagementDbContext();
        public void SetCollageetails(Collage collage)
        {
            db.Collages.Add(collage);
            db.SaveChanges();
             
        }

        public void CreateEvent(EventDetail eventdetail)
        {
            try
            {
                db.EventDetails.Add(eventdetail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                ExceptionTracker.SendErrorToText(ex);
            }
        }

        public void CreaeUser(User userDetail)
        {
            try
            {
                db.Users.Add(userDetail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
        }
        
    }
}
