using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using finalproject_se1.Models;

namespace finalproject_se1.Controllers
{
    public class CartController : Controller
    {
        public WareHousemanagementEntities db=new WareHousemanagementEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"]==null) 
            { 
                cart = new Cart();
                Session["Cart"]=cart;
            }
            return cart;
        }
        public ActionResult Addtocart(String id)
        {
            var pro=db.tblGood.SingleOrDefault(s=>s.goodID==id);
            if(pro != null) 
            { 
                GetCart().Add(pro);
            }
            return RedirectToAction("Showtocart", "Cart");
        }
        public ActionResult Showtocart()
        {
            if (Session["Cart"]==null)
                return RedirectToAction("Showtocart","Cart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public PartialViewResult CartI()
        {
            int totalI = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart!=null)
                totalI = cart.TotalQ();
                ViewBag.QuantityC=totalI;
                return PartialView("CartI");
        }
        public ActionResult UpdateQ(FormCollection form) 
        {
            Cart cart = Session["Cart"] as Cart;
            String goodid = form["goodid"];
            int quantity = int.Parse(form["qa"]);
            cart.UpdateQ(goodid, quantity);
            return RedirectToAction("Showtocart", "Cart");
        }
        public ActionResult RemoveCart(String id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveC(id);
            return RedirectToAction("Showtocart", "Cart");

        }
    }
}