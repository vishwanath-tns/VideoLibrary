using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary.Models;
using System.Data.Entity;
using System.Linq;
using VideoLibrary.ViewModels;

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

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            else
            {
                try
                {
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    _context.SaveChanges();
                }
                catch(Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                
            }
            
            return RedirectToAction("Index", "Movies");
        }
    }
}