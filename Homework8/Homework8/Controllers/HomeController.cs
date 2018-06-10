using Homework8.DAL;
using Homework8.DAL.Abstract;
using Homework8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Database context
        /// </summary>
        ArtistContext db = new ArtistContext();

        private readonly IArtistRepository repository;

        public HomeController(IArtistRepository artistRepository)
        {
            repository = artistRepository;
        }

        /// <summary>
        /// Get method for the homepage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        /// <summary>
        /// Get method for Artist
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Artist()
        {
            return View(repository.All);
        }

        /// <summary>
        /// Get method for Artwork
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Artwork()
        {
            return View(db.Artworks.ToList());
        }

        /// <summary>
        /// Get for Classification
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Classification()
        {
            return View(db.Classifications.ToList());
        }

        /// <summary>
        /// Detials get method for Artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Artist art = db.Artists.Find(id);
            if(art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        /// <summary>
        /// Get method for Create
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates and Posts a review
        /// </summary>
        /// <param name="artist"></param>
        /// <returns> Redirect to the Index page whether or not a reviewis posted</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID, FullName, DOB, City")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        /// <summary>
        /// Edit Get method for Artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Artist art = db.Artists.Find(id);
            if(art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        /// <summary>
        /// Edit Post method for Artist
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID, FullName, DOB, City")] Artist artist)
        {
            if(ModelState.IsValid)
            {
                if(artist.DOB > System.DateTime.Now)
                {
                    return View(artist);
                }
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        /// <summary>
        /// Get method for delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Artist art = db.Artists.Find(id);
            if(art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist art = db.Artists.Find(id);
            db.Artists.Remove(art);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get method for GenreResult
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GenreResult(int? id)
        {
            if(id == null)
            {
                return null;
            }
            //List<Classification> classlist = db.Classifications.Where(p => p.GenreID == id).ToList();
            //List<Models.ArtworkByGenre> genreResultList = new List<Models.ArtworkByGenre>();
            //for(int i = 0; i < classlist.Count; i++)
            //{
            //    Models.ArtworkByGenre val = new Models.ArtworkByGenre();
            //    val.Title = db.Artworks.Find(classlist[i].ArtworkID).Title;
            //    int identifier = db.Artworks.Find(classlist[i].ArtworkID).ArtistID;
            //    val.FullName = db.Artists.Find(identifier).FullName;
            //    Console.WriteLine(val);
            //    genreResultList.Add(val);

            //}

            //var jsonSerialiser = new JavaScriptSerializer();
            //var json = jsonSerialiser.Serialize(genreResultList.ToArray());

            var artCollection = db.Genres.Where(g => g.GenreID == id)
                                .Select(x => x.Classifications)
                                .FirstOrDefault()
                                .Select(x => new { x.Artwork.Title, x.Artwork.Artist.FullName })
                                .OrderBy(x => x.Title)
                                .ToList();
            return Json(artCollection, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}