using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRental.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class modelesController : Controller
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
            var modeles = db.modeles.Include(m => m.marque);
            return View(modeles.ToList());
        }

        // GET: modeles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(modele);
        }

        // GET: modeles/Create
        public ActionResult Create()
        {
            ViewBag.idmarque = new SelectList(db.marques, "idmarque", "nom_marque"); 
            ViewBag.Message = "ADMIN";
            return View();
        }

        // POST: modeles/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idmodele,nom_modele,idmarque,datesortie")] modele modele)
        {
            if (ModelState.IsValid)
            {
                db.modeles.Add(modele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmarque = new SelectList(db.marques, "idmarque", "nom_marque", modele.idmarque);
            ViewBag.Message = "ADMIN";
            return View(modele);
        }

        // GET: modeles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.idmarque = new SelectList(db.marques, "idmarque", "nom_marque", modele.idmarque);
            ViewBag.Message = "ADMIN";
            return View(modele);
        }

        // POST: modeles/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idmodele,nom_modele,idmarque,datesortie")] modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idmarque = new SelectList(db.marques, "idmarque", "nom_marque", modele.idmarque);
            ViewBag.Message = "ADMIN";
            return View(modele);
        }

        // GET: modeles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modele modele = db.modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(modele);
        }

        // POST: modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modele modele = db.modeles.Find(id);
            db.modeles.Remove(modele);
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
