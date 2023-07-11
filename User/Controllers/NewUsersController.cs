using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using User.Models;

namespace User.Controllers
{
    public class NewUsersController : Controller
    {
        private UserContext db = new UserContext();

        // GET: NewUsers
        public ActionResult Index()
        {
           
            return View(db.NewUsers.ToList());
        }

        // GET: NewUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUser newUser = db.NewUsers.Find(id);
            if (newUser == null)
            {
                return HttpNotFound();
            }
            return View(newUser);
        }

        // GET: NewUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password")] NewUser newUser, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {

                newUser.Image = new byte[image1.ContentLength];
                image1.InputStream.Read(newUser.Image, 0, image1.ContentLength);
                db.NewUsers.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(newUser);
        }

        // GET: NewUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUser newUser = db.NewUsers.Find(id);
            if (newUser == null)
            {
                return HttpNotFound();
            }
            return View(newUser);
        }

        // POST: NewUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,File")] NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUser);
        }

        // GET: NewUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUser newUser = db.NewUsers.Find(id);
            if (newUser == null)
            {
                return HttpNotFound();
            }
            return View(newUser);
        }

        // POST: NewUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUser newUser = db.NewUsers.Find(id);
            db.NewUsers.Remove(newUser);
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
