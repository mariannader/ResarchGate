using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResarchGate.Models;

namespace ResarchGate.Controllers
{
    public class tbl_paperController : Controller
    {
        private dbreserchgateEntities db = new dbreserchgateEntities();

        // GET: tbl_paper
        public ActionResult Index(string currentUser)
        {
            var tbl_paper = db.tbl_paper.Include(t => t.tbl_user);
            ViewBag.user = currentUser;
            return View(tbl_paper.ToList());
        }

        // GET: tbl_paper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paper tbl_paper = db.tbl_paper.Find(id);
            if (tbl_paper == null)
            {
                return HttpNotFound();
            }
            return View(tbl_paper);
        }

        // GET: tbl_paper/Create
        public ActionResult Create()
        {
            ViewBag.p_fk_user = new SelectList(db.tbl_user, "u_id", "u_name");
            return View();
        }

        // POST: tbl_paper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,p_name,p_file,p_fk_user")] tbl_paper tbl_paper)
        {
            if (ModelState.IsValid)
            {
                db.tbl_paper.Add(tbl_paper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.p_fk_user = new SelectList(db.tbl_user, "u_id", "u_name", tbl_paper.p_fk_user);
            return View(tbl_paper);
        }

        // GET: tbl_paper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paper tbl_paper = db.tbl_paper.Find(id);
            if (tbl_paper == null)
            {
                return HttpNotFound();
            }
            ViewBag.p_fk_user = new SelectList(db.tbl_user, "u_id", "u_name", tbl_paper.p_fk_user);
            return View(tbl_paper);
        }

        // POST: tbl_paper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,p_name,p_file,p_fk_user")] tbl_paper tbl_paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_paper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.p_fk_user = new SelectList(db.tbl_user, "u_id", "u_name", tbl_paper.p_fk_user);
            return View(tbl_paper);
        }

        // GET: tbl_paper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_paper tbl_paper = db.tbl_paper.Find(id);
            if (tbl_paper == null)
            {
                return HttpNotFound();
            }
            return View(tbl_paper);
        }

        // POST: tbl_paper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_paper tbl_paper = db.tbl_paper.Find(id);
            db.tbl_paper.Remove(tbl_paper);
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
