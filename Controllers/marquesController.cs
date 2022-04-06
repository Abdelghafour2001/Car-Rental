using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;
using CarRental.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRental.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class marquesController : Controller
    {
        private carrentalEntities db = new carrentalEntities();

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                if (s[0].ToString() == "ADMIN")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        // GET: reservations
        public ActionResult Index()
        {
            var user = User.Identity;
            if (isAdminUser())
            {
                ViewBag.Message = "ADMIN";
            }
            else
            {

                ViewBag.Message = user.Name;
            }
            return View(db.marques.ToList());
        }

        // GET: marques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marque marque = db.marques.Find(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(marque);
        }

        // GET: marques/Create
        public ActionResult Create()
        {
            ViewBag.Message = "ADMIN";
            return View();
        }

        // POST: marques/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmarque,nom_marque,pays,logo")] marque marque, HttpPostedFileBase file)
        {
            

             if (ModelState.IsValid)
             {
                 db.marques.Add(marque);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
            ViewBag.Message = "ADMIN";
            return View(marque);
        }

        // GET: marques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marque marque = db.marques.Find(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(marque);
        }

        // POST: marques/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmarque,pays,nom_marque,logo")] marque marque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "ADMIN";
            return View(marque);
        }

        // GET: marques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            marque marque = db.marques.Find(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(marque);
        }
        public ActionResult ModeleByMarques(int? id)
        {
            return View(db.ModeleByMarques(id).ToList());
        }

        // POST: marques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            marque marque = db.marques.Find(id);
            db.marques.Remove(marque);
            db.SaveChanges();
            ViewBag.Message = "ADMIN";
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
