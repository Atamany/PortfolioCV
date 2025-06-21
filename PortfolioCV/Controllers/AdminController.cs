using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IActionResult Index()
        {
            ViewBag.Proje= db.Projes.Count();
            ViewBag.Makale = db.Makales.Count();
            ViewBag.Blog = db.Blogs.Count();
            ViewBag.Sertifika = db.Sertifikas.Count();
            ViewBag.Referans = db.Referanss.Count();
            ViewBag.Film = db.Films.Count();
            ViewBag.Dizi = db.Dizis.Count();
            ViewBag.Kitap = db.Kitaps.Count();
            ViewBag.Podcast = db.Podcasts.Count();
            ViewBag.Tiyatro = db.Tiyatros.Count();
            return View();
        }
    }
}
