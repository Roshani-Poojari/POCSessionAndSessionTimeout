using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POCSession.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (Session["Username"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Simulate user validation
            if (username == "testuser" && password == "password")
            {
                Session["Username"] = username;
                Session["LoggedInTime"] = DateTime.Now;
                return RedirectToAction("Index", "Home");
            }

            // If login fails, remain on the login page
            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Clears all session data
            return RedirectToAction("Login");
        }

        public ActionResult SessionTimeout()
        {
            return View();
        }
    }
}