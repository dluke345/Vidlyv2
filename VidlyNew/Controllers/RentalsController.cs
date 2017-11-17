using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;

namespace VidlyNew.Controllers
{
    public class RentalsController : Controller
    {
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        // GET: Rentals
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            return View();
        }
    }
}