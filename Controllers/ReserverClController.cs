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
     [Authorize]
    public class ReserverClController : Controller
    {
        // GET: ReserverCl
        private carrentalEntities db = new carrentalEntities();

        public ActionResult Index()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            client x = db.clients.Where(d => d.email.Equals(user.Name)).FirstOrDefault();
            if(x == null)
            {
                ViewBag.hasacc = 0;
            }
            else
            {
                ViewBag.hasacc = 1;
            }
            return View();
        }
        public ActionResult ViewRes()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            int x = db.clients.Where(d => d.email.Equals(user.Name)).FirstOrDefault().idclient ;
            List<reservation> reservations = db.reservations.Where(d => d.idclient == x).ToList();
            
            return View(reservations);
        }
        // GET: clients/Create
        public ActionResult Create()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idclient,nom_cl,prenom_cl,tel_cl,adresse_cl,CIN_cl,email")] client client)
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            if (ModelState.IsValid)
            {
                client.email = user.Name;
                db.clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);

        }
        // GET: clients/Edit/5
        public ActionResult Edit()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            string email = user.Name;
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = db.clients.Where(c => c.email.Equals(email)).FirstOrDefault();
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idclient,nom_cl,prenom_cl,tel_cl,adresse_cl,CIN_cl,email")] client client)
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
           /* if (ModelState.IsValid)
            {
               
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View(client);
        }

        public ActionResult CreateRes()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRes([Bind(Include = "idreserv,idclient,idcar,objectif_reserv,kilometrage,date_debut,date_fin")] reservation reservation)
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            client x = db.clients.Where(c => c.email.Equals(user.Name)).FirstOrDefault();
            if (ModelState.IsValid)
            {
                reservation.idclient =x.idclient ;
                db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);

        }
        public ActionResult EditRes()
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            string email = user.Name;
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client x = db.clients.Where(c => c.email.Equals(user.Name)).FirstOrDefault();
            reservation res = db.reservations.Where(r=>r.idclient==x.idclient).FirstOrDefault();
            if (res == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat");
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRes([Bind(Include = "idreserv,idclient,idcar,objectif_reserv,kilometrage,date_debut,date_fin")] reservation reservation)
        {
            var user = User.Identity;
            ViewBag.Message = user.Name;
            ViewBag.idcar = new SelectList(db.voitures, "idcar", "immat");

            db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}