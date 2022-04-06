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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace CarRental.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class contratsController : Controller
    {
        private carrentalEntities db = new carrentalEntities();

        
        // GET: reservations
        public ActionResult Index()
        {
            var user = User.Identity;
           
                ViewBag.Message = "ADMIN";
           
            var contrats = db.contrats.Include(c => c.client).Include(c => c.voiture).Include(c => c.reservation);

            return View(contrats.ToList());
        }
        public ActionResult Export(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }
        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using(MemoryStream stream = new System.IO.MemoryStream())
            {
                

                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                
                pdfDoc.Open();
                pdfDoc.AddHeader("Cars.ma", "Car.ma");
                // pdfDoc.Add(new Chunk(""));
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(),"application/pdf","Contrat.pdf");
            }
        }

        // GET: contrats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }

        // GET: contrats/Create
        public ActionResult Create()
        {
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl");
            ViewBag.idCar = new SelectList(db.voitures, "idcar", "immat");
            ViewBag.idreserv = new SelectList(db.reservations, "idreserv", "objectif_reserv");
            ViewBag.Message = "ADMIN";
            return View();
        }

        // POST: contrats/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontrat,idclient,date_debut,date_fin,montant_contrat,idCar,idreserv")] contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.contrats.Add(contrat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", contrat.idclient);
            ViewBag.idCar = new SelectList(db.voitures, "idcar", "immat", contrat.idCar);
            ViewBag.idreserv = new SelectList(db.reservations, "idreserv", "objectif_reserv", contrat.idreserv);
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }

        // GET: contrats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", contrat.idclient);
            ViewBag.idCar = new SelectList(db.voitures, "idcar", "immat", contrat.idCar);
            ViewBag.idreserv = new SelectList(db.reservations, "idreserv", "objectif_reserv", contrat.idreserv);
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }

        // POST: contrats/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontrat,idclient,date_debut,date_fin,montant_contrat,idCar,idreserv")] contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idclient = new SelectList(db.clients, "idclient", "nom_cl", contrat.idclient);
            ViewBag.idCar = new SelectList(db.voitures, "idcar", "immat", contrat.idCar);
            ViewBag.idreserv = new SelectList(db.reservations, "idreserv", "objectif_reserv", contrat.idreserv);
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }

        // GET: contrats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "ADMIN";
            return View(contrat);
        }

        // POST: contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contrat contrat = db.contrats.Find(id);
            db.contrats.Remove(contrat);
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
