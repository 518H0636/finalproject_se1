using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalproject_se1.Models;

namespace finalproject_se1.Controllers
{
    public class HomeController : Controller
    {
        WareHousemanagementEntities db = new WareHousemanagementEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("LogIn","Home");
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(tblAgent tBLAgent)
        {
            var checkLogin = db.tblAgent.Where(x => x.agentName.Equals(tBLAgent.agentName) && x.agentPass.Equals(tBLAgent.agentPass)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["agentName"] = tBLAgent.agentName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong agent name or password";
            }
            return View();
        }
    }
}