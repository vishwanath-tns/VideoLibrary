using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.Models;
using System.Data.Entity;
using System.Linq;

namespace VideoLibrary.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(mbox => mbox.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            return View(movie);
           
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