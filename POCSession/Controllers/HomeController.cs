using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POCSession.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            // Check if session has timed out
            DateTime? loggedInTime = Session["LoggedInTime"] as DateTime?;
            if (loggedInTime != null && DateTime.Now > loggedInTime.Value.AddMinutes(1))
            {
                Session.Clear();
                return RedirectToAction("SessionTimeout", "Account");
            }

            return View();
        }
    }
}