using BusinessLayer;
using BusinessLayer.BusinessModel;
using EventManagmentWeb.ActionFilters;
using EventManagmentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagmentWeb.Controllers
{
    [TeacherAuthorizeAttribute]
    public class TeacherController : Controller
    {
        private ApplicationLEvelBusinessOperation applicationLEvelBusinessOperation = new ApplicationLEvelBusinessOperation();
        private TeacherLEvelBusinessOperation teacherLEvelBusinessOperation = new TeacherLEvelBusinessOperation();
        // GET: Teacher
        public ActionResult Index()
        {
            ViewData["headerName"] = "Teacher Home";
            return View();
        }

        public ActionResult RegistrationMarks(int id)
        {
            List<EventRegistrationmarkModel> EventRegistrationmarkList = new List<EventRegistrationmarkModel>();
            List<EventRegistrationBusinessModel> EventRegistrationBModel = new List<EventRegistrationBusinessModel>();
            EventRegistrationBModel = teacherLEvelBusinessOperation.UserEventRegistration(id);

            foreach (EventRegistrationBusinessModel item in EventRegistrationBModel)
            {
                UserBusinessModel userBusinessModel = new UserBusinessModel();
                userBusinessModel = applicationLEvelBusinessOperation.GetUserDetailByUserId(item.UserID);

                EventDetailBusinessModel eventDetailBusinessModel = new EventDetailBusinessModel();
                eventDetailBusinessModel = applicationLEvelBusinessOperation.GetEventDetailById(item.EventDetailsID);

                EventRegistrationmarkModel EventRegistrationItem = new EventRegistrationmarkModel
                {
                    EventDetailID = item.EventDetailsID,
                    EventName = eventDetailBusinessModel.EventName,
                    EventRegistrationID = item.EventRegistrationID,
                    FirstName = userBusinessModel.FirstName,
                    LastName = userBusinessModel.LastName,
                    UserAttendance = item.UserAttendance,
                    UserID = userBusinessModel.UserID
                };

                UserProfile userProfile = new UserProfile();
                EventRegistrationmarkList.Add(EventRegistrationItem);
            }
            return View(EventRegistrationmarkList);
        }

        
        public JsonResult UpdateRegistrationMarks(int EventRegistrationID,bool UserAttendance)
        {
            EventRegistrationBusinessModel attendance = new EventRegistrationBusinessModel
            {
                EventRegistrationID = EventRegistrationID,
                UserAttendance = UserAttendance
            };
            teacherLEvelBusinessOperation.UpdateAttendance(attendance);

            return new JsonResult { Data = attendance, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}