using BusinessLayer;
using BusinessLayer.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventManagmentWeb.Controllers
{
    public class MyActionAttribute : ActionFilterAttribute, IActionFilter
    {
        private ApplicationLEvelBusinessOperation aplicationLEvelBusinessOperation = new ApplicationLEvelBusinessOperation();
        /// <summary>
        /// add user role session after sucessfully logged
        /// </summary>
        /// <param name="filterContext"></param>
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session.Contents["UserID"])))
            {
                int ID = (int)filterContext.HttpContext.Session.Contents["UserID"];
                UserRoleBusinessModel userRoleDetails = new UserRoleBusinessModel();
                userRoleDetails = aplicationLEvelBusinessOperation.GetUserRolebyUserID(ID);
                filterContext.HttpContext.Session.Contents["UserRole"] = userRoleDetails.RoleName;
            }
        }
        
    }
}