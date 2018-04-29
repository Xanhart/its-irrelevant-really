using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScavengerHunt.Models;

namespace ScavengerHunt.Controllers
{
    public class PhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Photos
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            // sets up the name of the file to save
            var date = DateTime.Now;
            string userID = HttpContext.Request.Form["userID"];
            string animalName = HttpContext.Request.Form["selectedAnimal"];
            string fileName = $"c:/Scavenger/{userID}-{animalName}-{date:MM-dd-yy_HH-mm-ss}.png";

            // converts the file toa  byte array which can be saved
            string dataURL = HttpContext.Request.Form["imageData"];            
            var base64Data = Regex.Match(dataURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] bytes = Convert.FromBase64String(base64Data);

            // saves the actual file to the generated location
            System.IO.File.WriteAllBytes(fileName, bytes);

            //Saves the photo information to the DB
            Photo photo = new Photo
            {
                PhotoAnimalName = animalName,
                UserID = userID,
                PhotoImageLocation = fileName
            };
            db.Photos.Add(photo);
            db.SaveChanges();

            return Json(new { success = true });
        }

        // GET: Photos/UserPhotos
        [HttpGet]
        public ActionResult UserPhotos(string UserID)
        {
            
            return Json(db.Photos.ToList(),JsonRequestBehavior.AllowGet);
        }

        // POST: Photos/ImageData
        // using a POST here is BS, but at the same time it makes everyting work without having to mess around with escaping things sooo....
        [HttpPost]
        public ActionResult ImageData()
        {
            var PhotoPath = HttpContext.Request.Form["path"];
            var imageString = System.IO.File.ReadAllBytes(PhotoPath);
            var baseString = Convert.ToBase64String(imageString);
            return Json(new { success = true, baseString = baseString });
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,PhotoImageLocation,PhotoGPS,PhotoAnimalName")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
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
