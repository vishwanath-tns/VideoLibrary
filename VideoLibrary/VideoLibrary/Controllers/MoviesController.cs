using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.Models;

namespace VideoLibrary.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetAllMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetAllMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Bahubali-1"},
                new Movie { Id = 1, Name = "Bahubali-2"}
            };
        }
    }
}