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
    public class ValiderController : Controller
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
            var reservations = db.reservations.Include(r => r.client).Include(r => r.voiture).Where(r => r.valide == null);
            return View(reservations.ToList());
        }
        
        public ActionResult Validation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservations.Find(id);
            reservation.valide = true;
            db.SaveChanges();
            ViewBag.Message = "ADMIN";
            return RedirectToAction("Index"); 
        }
    }
}