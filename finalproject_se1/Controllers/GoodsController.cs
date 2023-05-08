using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finalproject_se1.Models;

namespace finalproject_se1.Controllers
{
    public class GoodsController : Controller
    {
        private WareHousemanagementEntities db = new WareHousemanagementEntities();

        // GET: Goods
        public ActionResult Index()
        {
            return View(db.tblGood.ToList());
        }

        // GET: Goods/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGood tblGood = db.tblGood.Find(id);
            if (tblGood == null)
            {
                return HttpNotFound();
            }
            return View(tblGood);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "goodID,goodName,cateID,goodAmount,unitPrice,unitSold,importnote")] tblGood tblGood)
        {
            if (ModelState.IsValid)
            {
                db.tblGood.Add(tblGood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGood);
        }

        // GET: Goods/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGood tblGood = db.tblGood.Find(id);
            if (tblGood == null)
            {
                return HttpNotFound();
            }
            return View(tblGood);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "goodID,goodName,cateID,goodAmount,unitPrice,unitSold,importnote")] tblGood tblGood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGood);
        }

        // GET: Goods/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGood tblGood = db.tblGood.Find(id);
            if (tblGood == null)
            {
                return HttpNotFound();
            }
            return View(tblGood);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblGood tblGood = db.tblGood.Find(id);
            db.tblGood.Remove(tblGood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
