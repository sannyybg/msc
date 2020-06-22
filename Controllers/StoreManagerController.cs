using muscshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace muscshop.Controllers
{
    public class StoreManagerController : Controller
    {
        private static FakeDatabase _database = new FakeDatabase();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = _database.Albums;

            return View(albums);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var album = _database.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", album.Artist.ArtistId);
            ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album updateAlbum)
        {

            if(ModelState.IsValid)
            {

                //updateAlbum.Title = Request.Form["Title"];
                //updateAlbum.Price = double.Parse(Request.Form["Price"]);
                //updateAlbum.ReleaseYear = int.Parse(Request.Form["ReleaseYear"]);
                //updateAlbum.AlbumUrl = Request.Form["AlbumUrl"];
                //updateAlbum.AlbumId = int.Parse(Request.Form["AlbumId"]);

                _database.UpdateAlbum(updateAlbum);

                return RedirectToAction("index");
            }

            else
            {
                //var errors = ModelState.Values.Where(x => x.Errors.Count > 0);

                List<KeyValuePair<string, ModelState>> errorList = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();

                ViewBag.ErrorList = errorList;

                return Edit(updateAlbum.AlbumId);

                //var album = _database.Albums.Where(x => x.AlbumId == updateAlbum.AlbumId).FirstOrDefault();
                //ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", album.Artist.ArtistId);
                //ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);
                //return View(album);
            }

        }

        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", 1);
            ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album newalbum)
        {
            if (!ModelState.IsValid)
            {
                List<KeyValuePair<string, ModelState>> errorList = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();

                ViewBag.ErrorList = errorList;
                return Create();
            }

            

            _database.AddAlbum(newalbum);

            return RedirectToAction("index");
            
        }

        public ActionResult Search(string parameter)
        {
            var albums = _database.Albums.Where(x => x.Title.ToLower().Contains(parameter.ToLower()));

            return View("index", albums);
        }
    }
}