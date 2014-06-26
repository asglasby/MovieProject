using MovieProject.Adapters.Adapters;
using MovieProject.Adapters.Interfaces;
using MovieProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        private IMovie _adapter;

        public HomeController()
        {
            _adapter = new MovieAdapter();
        }
        public ActionResult Index()
        {
            return View(_adapter.GetMovies());
        }

        public ActionResult View(int id)
        {
            return View(_adapter.GetMovie(id));
        }

        public ActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMovie(string title, string summary, string imageUrl)
        {
            Movie movie = new Movie(){Title = title, Summary = summary, ImageUrl = imageUrl};
            int Id = _adapter.CreateMovie(movie);
            return RedirectToAction("View", new { id = Id });
        }

        public ActionResult UpdateMovie(int id)
        {
            return View(_adapter.GetMovie(id));
        }

        [HttpPost]
        public ActionResult UpdateMovie(int id, string title, string summary, string imageUrl)
        {
            Movie movie = new Movie() { Title = title, Summary = summary, ImageUrl = imageUrl };
            _adapter.UpdateMovie(id, movie);
            return RedirectToAction("View", new { id = id });
        }

        public ActionResult DeleteMovie(int id)
        {
            _adapter.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}