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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRental.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class voituresController : Controller
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
            var voitures = db.voitures.Include(v => v.category).Include(v => v.modele);
            return View(voitures.ToList());
        }

        // GET: voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            Photo photo = db.Photos.Find(id);
            voiture.OnePhoto = photo;
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(voiture);
        }

        // GET: voitures/Create
        public ActionResult Create()
        {
            ViewBag.idcat = new SelectList(db.categories, "idcat", "libelle_cat");
            ViewBag.idmodele = new SelectList(db.modeles, "idmodele", "nom_modele");
            ViewBag.Message = "ADMIN";
            return View();
        }

        // POST: voitures/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(voiture voiture)
        {
            Photo photo = new Photo();
            string filename = Path.GetFileNameWithoutExtension(voiture.ImageFile.FileName);
            string extension = Path.GetExtension(voiture.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssff") + extension;
            photo.ImagePath = "~/Image/"+filename;
            filename = Path.Combine(Server.MapPath("~/Image/"), filename);
            voiture.ImageFile.SaveAs(filename);
            photo.idCar = voiture.idcar;
            if (ModelState.IsValid)
            {
                db.voitures.Add(voiture);
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "ADMIN";
            ViewBag.idcat = new SelectList(db.categories, "idcat", "libelle_cat", voiture.idcat);
            ViewBag.idmodele = new SelectList(db.modeles, "idmodele", "nom_modele", voiture.idmodele);
            return View(voiture);
        }

        // GET: voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcat = new SelectList(db.categories, "idcat", "libelle_cat", voiture.idcat);
            ViewBag.idmodele = new SelectList(db.modeles, "idmodele", "nom_modele", voiture.idmodele);
            ViewBag.Message = "ADMIN";
            return View(voiture);
        }

        // POST: voitures/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcar,idcat,idmodele,immat,carte_grise,nbporte,nbplace,puissance,date_aquis,datedebut_assurance,datefin_assurance,cout_assurance,typecarburant,photo")] voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcat = new SelectList(db.categories, "idcat", "libelle_cat", voiture.idcat);
            ViewBag.idmodele = new SelectList(db.modeles, "idmodele", "nom_modele", voiture.idmodele);
            ViewBag.Message = "ADMIN";
            return View(voiture);
        }

        // GET: voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voiture voiture = db.voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(voiture);
        }
        public ActionResult ReservationsByCar(int? id)
        {
            ViewBag.Message = "ADMIN";
            return View(db.ReservationByCar(id).ToList());
        }




        // POST: voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            voiture voiture = db.voitures.Find(id);
            db.voitures.Remove(voiture);
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
