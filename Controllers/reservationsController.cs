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
    public class reservationsController : Controller
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
            var reservations = db.reservations.Include(r => r.client).Include(r => r.voiture).Where(r => r.valide == true);
            return View(reservations.ToList());
        }

        // GET: reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(reservation);
        }

        // GET: reservations/Create
        public ActionResult Create()
        {
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl");
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat");
            ViewBag.Message = "ADMIN";
            return View();
        }

        // POST: reservations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idreserv,idclient,idcar,objectif_reserv,kilometrage,date_debut,date_fin")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", reservation.idclient);
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat", reservation.idcar);
            ViewBag.Message = "ADMIN";
            return View(reservation);
        }

        // GET: reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", reservation.idclient);
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat", reservation.idcar);
            ViewBag.Message = "ADMIN";
            return View(reservation);
        }

        // POST: reservations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idreserv,idclient,idcar,objectif_reserv,kilometrage,date_debut,date_fin")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", reservation.idclient);
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat", reservation.idcar);
            ViewBag.Message = "ADMIN";
            return View(reservation);
        }

        // GET: reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(reservation);
        }

        // POST: reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
            db.SaveChanges();
            ViewBag.Message = "ADMIN";
            return RedirectToAction("Index");
        }
        public ActionResult ContratByReservation(int id)
        {
            return View(db.contratByReservation(id).ToList());
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
