using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.Controllers
{
    public class DefaultController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IActionResult Index()
        {
            var deger = db.Hakkindas.FirstOrDefault();
            return View(deger);
        }
        public IActionResult Proje()
        {
            var deger = db.Projes.OrderByDescending(x=>x.ProjeId).ToList();
            return View(deger);
        }
        public IActionResult Sosyal()
        {
            var deger = db.Sosyals.ToList();
            return View(deger);
        }
        public IActionResult Makale()
        {
            var deger = db.Makales.OrderByDescending(x => x.MakaleId).ToList();
            return View(deger);
        }
        public IActionResult Blog()
        {
            var deger = db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return View(deger);
        }
        public IActionResult Referanslar()
        {
            var deger = db.Referanss.OrderByDescending(x => x.ReferansId).ToList();
            return View(deger);
        }
        public IActionResult Sertifikalar()
        {
            var deger = db.Sertifikas.OrderByDescending(x => x.SertifikaId).ToList();
            return View(deger);
        }
    }
}
