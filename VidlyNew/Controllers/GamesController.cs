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
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Games
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genreTypes = _context.Genres.ToList();

            var viewModel = new GameFormViewModel
            {
                Genres = genreTypes
            };

            return View("GameForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(m => m.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }

            if (game.Id == 0)
                _context.Games.Add(game);

            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);

                gameInDb.Name = game.Name;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.NumberAvailable = game.NumberAvailable;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }


        // GET: Game
        [Route("Games/Details/{id}")]
        public ActionResult Details(int id)
        {
            var game = _context.Games
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }
    }
}