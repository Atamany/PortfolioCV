using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class HakkindaController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index()
        {
            var value = db.Hakkindas.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Hakkinda model)
        {
            var value = db.Hakkindas.FirstOrDefault();
            if (value != null)
            {
                value.AdSoyad = model.AdSoyad;
                value.Telefon = model.Telefon;
                value.Email = model.Email;
                value.HakkindaMetni = model.HakkindaMetni;
            }
            else
            {
                db.Hakkindas.Add(model);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
