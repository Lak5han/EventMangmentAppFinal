using BusinessLayer.BusinessModel;
using DataLayer;
using ExceptionLogging;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Eventmanagement.DataBaseOperatios;

namespace BusinessLayer
{
    public class AdminBusinessOperations
    {
        private AdminDataBaseOperation adminDataBaseOperation = new AdminDataBaseOperation();
        private ApplicationLevelDataBaseOps applicationLevelDataBaseOps = new ApplicationLevelDataBaseOps();

        //public void SetRoles()
        //{
        //    try
        //    {
        //        Role role = new Role
        //        {
        //            RoleID = 1,
        //            RoleName = "Admin",
        //            CreateDate = DateTime.Now,
        //            MdifiedDate = DateTime.Now
        //        };
        //        db.Roles.Add(role);
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionTracker.SendErrorToText(ex);
        //    }

        //}

        public void SetCollageName(CollageBusinessModel collage )
        {
            Collage collageDetail = new Collage
            {
                CollageName = collage.CollageName,
                CreateDate = DateTime.Now,
                MdifiedDate = DateTime.Now
            };

            adminDataBaseOperation.SetCollageetails(collageDetail);
        }



        public void CreaeUser(UserBusinessModel userDetail)
        {
            User UserDetails = applicationLevelDataBaseOps.GetUserDetailByUserName(userDetail.UserName);
            if (UserDetails != null)
            {
                try
                {                    
                    User user = new User
                    {
                        FirstName = userDetail.FirstName,
                        LastName = userDetail.LastName,
                        Password = ApplicationLEvelBusinessOperation.Encrypt(userDetail.Password.Trim()),
                        UserName = userDetail.UserName,
                        CollageID = userDetail.CollageID,
                        CreateDate = DateTime.Now,
                        MdifiedDate = DateTime.Now
                    };
                    adminDataBaseOperation.CreaeUser(user);
                }
                catch (Exception ex)
                {
                    ExceptionTracker.SendErrorToText(ex);
                }
            }            
        }
        /// <summary>
        /// convert to the eventdetail entity and pass to the data base layer to update
        /// </summary>
        /// <param name="eventDetails"></param>
        /// <returns></returns>
        public bool CreateEvent(EventDetailBusinessModel eventDetails)
        {
            EventDetail eventDetailToUpdate = new EventDetail();
            bool isEventCreated = false;
            if (eventDetails != null)
            {
                try
                {
                    EventDetail newEvent = new EventDetail
                    {
                        CreateDate = DateTime.Now,
                        MdifiedDate = DateTime.Now, EventDate = eventDetails.EventDate,
                        EventDescription = eventDetails.EventDescription,
                        EventName = eventDetails.EventName,
                        EventType = eventDetails.EventType,
                        CollageID = eventDetails.CollageID
                    };
                    adminDataBaseOperation.CreateEvent(newEvent);
                    isEventCreated= true;
                }
                catch (Exception ex)
                {
                    ExceptionTracker.SendErrorToText(ex);
                    isEventCreated= false;
                }
            }
            return isEventCreated;
        }
    }
}
