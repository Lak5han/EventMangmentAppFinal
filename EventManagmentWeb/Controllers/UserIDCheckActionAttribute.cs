using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventManagmentWeb.Controllers
{
    public class CheckIsAdminActionAttribute : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// check user has been logged or not, only singin users can access
        /// </summary>
        /// <param name="filterContext"></param>
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            string UserID = Convert.ToString(filterContext.HttpContext.Session.Contents["UserID"]);
            string UserRole = Convert.ToString(filterContext.HttpContext.Session.Contents["UserRole"]);
            if ((string.IsNullOrEmpty(UserID)) && (UserRole != "Admin"))
            {
                
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {{"controller", "ApplicationHome"}, {"action", "Login"}});
            }
        }
    }
}