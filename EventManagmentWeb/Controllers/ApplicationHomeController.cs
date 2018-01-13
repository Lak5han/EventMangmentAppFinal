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
                    string user = Convert.ToString(Session["UserRole"]);
                    //string teacher = "Teacher";
                    //FormsAuthentication.SetAuthCookie(,);
                    if (Convert.ToString(Session["UserRole"]) == "Admin")
                        return RedirectToAction("AdminHome", "Admin");
                    else if (Convert.ToString(Session["UserRole"]) == "Student")
                        return RedirectToAction("Index", "Student");
                    else
                        return RedirectToAction("Index", "Teacher");
                    //if (Convert.ToString(Session["UserRole"]).ToLower() == teacher.ToLower())
                    //    return RedirectToAction("Index", "Teacher");
                }                
            }
            return View(objUser);
        }

        public ActionResult CreateUser()
        {
          ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");
          ViewBag.AllUserRoles = new SelectList(StaticMethod.GetAllUserRoles(), "RoleID", "RoleName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserProfile objUser, string AllCollages,string AllUserRoles)
        {
            if (ModelState.IsValid)
            {
                objUser.CollageID = Convert.ToInt32(AllCollages);
                objUser.RoleID = string.IsNullOrEmpty(AllUserRoles) ? 1002 : Convert.ToInt32(AllUserRoles);
                UserBusinessModel userProfile = new UserBusinessModel { FirstName = objUser.FirstName,
                    LastName = objUser.LastName,
                    UserName = objUser.UserName,
                    Password = objUser.Password,
                    CollageID = objUser.CollageID,
                    RoleID = objUser.RoleID
                };

                adminBusinessOperations.CreaeUser(userProfile);
            }
            ViewBag.AllCollages = new SelectList(StaticMethod.GetAlCollages(), "CollageID", "CollageName");
            ViewBag.AllUserRoles = new SelectList(StaticMethod.GetAllUserRoles(), "RoleID", "RoleName");
            return View(objUser);
        }
    }
}