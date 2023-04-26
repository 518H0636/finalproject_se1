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
        DBloginEntities db= new DBloginEntities();
        public ActionResult Index()
        {
            return View(db.tblLogin.ToList());
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
        public ActionResult LogIn(tblLogin tBLlogin)
        {
            var checkLogin = db.tblLogin.Where(x => x.agentname.Equals(tBLlogin.agentname) && x.agpassword.Equals(tBLlogin.agpassword)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["userid"]= tBLlogin.userid.ToString();
                Session["agentname"] = tBLlogin.agentname.ToString();
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