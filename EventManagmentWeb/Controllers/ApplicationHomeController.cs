using BusinessLayer;
using BusinessLayer.BusinessModel;
using EventManagmentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventManagmentWeb.Controllers
{
    [MyActionAttribute]
    public class ApplicationHomeController : Controller
    {
        private ApplicationLEvelBusinessOperation aplicationLEvelBusinessOperation = new ApplicationLEvelBusinessOperation();
        private AdminBusinessOperations adminBusinessOperations = new AdminBusinessOperations();
        // GET: Home
        //[Route("Admin/")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            int userID;
            bool IsValidUser = aplicationLEvelBusinessOperation.IsValidUser(objUser.UserName, objUser.Password,out userID);
            
            if (ModelState.IsValid)
            {
                if (IsValidUser)
                {
                    Session["UserID"] = userID;
                    Session["UserName"] = objUser.UserName.ToString();
                    
                    //FormsAuthentication.SetAuthCookie(,);
                    if(Convert.ToString(Session["UserRole"]) == "Admin")
                        return RedirectToAction("AdminHome", "Admin");
                }                
            }
            return View(objUser);
        }

        public ActionResult CreateUser()
        {
          ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserProfile objUser, string AllCollages)
        {
            if (ModelState.IsValid)
            {
                objUser.CollageID = Convert.ToInt32(AllCollages);
                UserBusinessModel userProfile = new UserBusinessModel { FirstName = objUser.FirstName,
                    LastName = objUser.LastName,
                    UserName = objUser.UserName,
                    Password = objUser.Password,
                    CollageID = objUser.CollageID
                };

                adminBusinessOperations.CreaeUser(userProfile);
            }
            ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");
            return View(objUser);
        }
    }
}