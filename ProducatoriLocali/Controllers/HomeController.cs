using ProducatoriLocali.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProducatoriLocali.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "ProducatoriLocali.Ro";

            MainPageProductsViewModel Mppvm = new MainPageProductsViewModel();

            Mppvm.MostViewed = db.Products.OrderBy(x => x.Title).Take(4).ToList();
            Mppvm.MostScored = db.Products.OrderBy(x => x.Price).Take(4).ToList();
            Mppvm.NewProducts = db.Products.OrderByDescending(x => x.PostStartDate).Take(4).ToList();
            return View(Mppvm);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}
