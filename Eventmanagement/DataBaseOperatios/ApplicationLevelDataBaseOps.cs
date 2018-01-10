using DataLayer;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmanagement.DataBaseOperatios
{
    public class ApplicationLevelDataBaseOps
    {
        private EventmanagementDbContext db = new EventmanagementDbContext();

        /// <summary>
        /// Get user detail by user name this will use in different places in the application
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserDetailByUserName(string username)
        {
            User userdetails = new User();
            try
            {
                userdetails = db.Users.First(c => c.UserName == username);
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return userdetails;
        }

        /// <summary>
        /// This will use in different places in the application and userrole will return user details and role details
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserRole GetUserRolebyUserID(int userID)
        {
            UserRole userdetails = new UserRole();
            try
            {
                userdetails = db.UserRoles.Where(c => c.User.UserID == userID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return userdetails;
        }

        public List<EventDetail> GetAllEventDetail()
        {
            List<EventDetail> listofEvents = new List<EventDetail>();
            try
            {
                listofEvents = db.EventDetails.ToList();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return listofEvents;
        }

        public List<Collage> GetAllCollage()
        {
            List<Collage> listofCollage = new List<Collage>();
            try
            {
                listofCollage = db.Collages.ToList();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return listofCollage;
        }

        public Role GetRoleDetailsByID(int roleID)
        {
            Role role = new Role();
            try
            {
                role = db.Roles.Where(c=>c.RoleID == roleID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return role;
        }
    }
}
