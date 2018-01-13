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
    [StudentAuthorizeAttribute]
    public class StudentController : Controller
    {
        private StudentBusinessOperations studentLevelDataBaseOps = new StudentBusinessOperations();
        // GET: Student
        public ActionResult Index()
        {
            ViewData["headerName"] = "Student Home";
            return View();
        }

        
        public ActionResult RegisterStudent(int id)
        {
            EventRegistrationBusinessModel eventRegistrationBusinessModel = new EventRegistrationBusinessModel
            {
                EventDetailsID = id,
                UserID = Convert.ToInt32(Session["UserID"])
            };
            studentLevelDataBaseOps.EventRegistration(eventRegistrationBusinessModel);
            return View("Index");
        }
    }
}