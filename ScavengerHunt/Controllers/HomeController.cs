using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ScavengerHunt.Models;

namespace ScavengerHunt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Animals.ToList());
        }
    }
}
