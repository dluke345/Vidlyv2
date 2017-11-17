using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
    public class GenresController : Controller
    {
        private ApplicationDbContext _context;

        public GenresController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Genres
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new GenreFormViewModel
            {
                Genre = new Genre()
            };

            return View("GenreForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var genre = _context.Genres.SingleOrDefault(c => c.Id == id);

            if (genre == null)
                return HttpNotFound();

            var viewModel = new GenreFormViewModel
            {
                Genre = genre
            };

            return View("GenreForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GenreFormViewModel
                {
                    Genre = genre
                };

                return View("GenreForm", viewModel);
            }

            if (genre.Id == 0)
                _context.Genres.Add(genre);
            else
            {
                var genreInDb = _context.Genres.Single(c => c.Id == genre.Id);

                genreInDb.Name = genre.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Genres");
        }


        //GET: Customer
        [Route("Genres/Details/{id}")]
        public ActionResult Details(int id)
        {
            var genre = _context.Genres
                .SingleOrDefault(c => c.Id == id);

            if (genre == null)
                return HttpNotFound();

            return View(genre);
        }


    }
}