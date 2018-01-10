using BusinessLayer;
using BusinessLayer.BusinessModel;
using EventManagmentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagmentWeb.Controllers
{
    [CheckIsAdminActionAttribute]
    public class AdminController : Controller
    {
        private AdminBusinessOperations adminBusinessOperations = new AdminBusinessOperations();
        private ApplicationLEvelBusinessOperation applicationLEvelBusinessOperation = new ApplicationLEvelBusinessOperation();
        // GET: Admin
        public ActionResult AdminHome()
        {
            //string userRole = TempData.Peek("UserRole").ToString();
            int userID = Convert.ToInt32(Session["UserID"]);
            ViewBag.IsAdmin = true;
            
            ViewData["headerName"] = "Admin Home Page";
            if (userID != 0)
                return View();
            else
                return RedirectToAction("Login", "ApplicationHome");
        }

        [HttpGet]
        public ActionResult collageDetails()
        {

            ViewData["headerName"] = "collage Details";
            return View();
        }

        [HttpPost]
        public ActionResult collageDetails(CollageModel collage)
        {
            CollageBusinessModel collageDetails = new CollageBusinessModel
            {
                CollageName = collage.CollageName
            };
            adminBusinessOperations.SetCollageName(collageDetails);

            return RedirectToAction("collageDetails"); 
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            @ViewData["headerName"] = "Create Event";
            ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EventDetailModel eventDetail, string AllCollages)
        {
            if(ModelState.IsValid)
            {
                eventDetail.CollageID = Convert.ToInt32(AllCollages);
                EventDetailBusinessModel eventBizModel = new EventDetailBusinessModel
                {                   
                    CollageID = eventDetail.CollageID,
                    EventDate = eventDetail.EventDate,
                    EventDescription = eventDetail.EventDescription,
                    EventName = eventDetail.EventName,
                    EventType = eventDetail.EventType
                };
                adminBusinessOperations.CreateEvent(eventBizModel);
                return RedirectToAction("ListOfEvents");
            }
            ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");            
            return View(eventDetail);
        }

        [HttpGet]
        public ActionResult ListOfEvents()
        {
            @ViewData["headerName"] = "Collage Events";
            List<EventDetailBusinessModel> allEvents = new List<EventDetailBusinessModel>();
            List<EventDetailModel> listofEvents = new List<EventDetailModel>();
            allEvents = applicationLEvelBusinessOperation.GetAllEvents();

            foreach (EventDetailBusinessModel item in allEvents)
            {
                EventDetailModel eventItem = new EventDetailModel
                {
                    EventName = item.EventName,
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetailID = item.EventDetailID,
                    EventType = item.EventType,
                    CollageID = item.CollageID
                };
                listofEvents.Add(eventItem);
            }

            //ModelState.AddModelError("EventName", "This is my server-side error.");
            return View(listofEvents);
        }
    }
}