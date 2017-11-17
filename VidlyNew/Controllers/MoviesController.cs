using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
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
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genreTypes = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genreTypes
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.MovieReleaseDate = movie.MovieReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                //movieInDb.MovieDateAdded = movie.MovieDateAdded;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        // GET: Movie
        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        //Manually adding movies at first
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name = "Shrek!"},
        //        new Movie {Id = 2, Name = "Wall-e"}
        //    };
        //}
    }
}