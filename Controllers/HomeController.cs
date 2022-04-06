using CarRental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             var user = User.Identity;
            if (isAdminUser()) { 
            ViewBag.Message = "ADMIN";
            }
            else
            {

                ViewBag.Message = user.Name;
            }
            return View();
        }

        public ActionResult About()      
        {
            var user = User.Identity;
            if (isAdminUser()) { 
            ViewBag.Message = "Admin";
            }
            else
            {

                ViewBag.Message = user.Name;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Notre page de contact.";

            return View();
        }
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
    }
}