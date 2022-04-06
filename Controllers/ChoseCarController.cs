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
    [Authorize]
    public class ChoseCarController : Controller
    {
        private carrentalEntities db = new carrentalEntities();
        // GET: ChoseCar
        public ActionResult Index()
        {
            List<voiture> voitures = db.voitures.ToList();
            foreach (voiture v in voitures)
            {
                Photo photo = db.Photos.Find(v.idcar);
                v.OnePhoto = photo;
            }

            return View(voitures);
        }
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
    }
}