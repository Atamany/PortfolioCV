using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class DeneyimController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index()
        {
            var deneyimler = db.Deneyims.OrderByDescending(x => x.DeneyimId).ToList();
            return View(deneyimler);
        }
        [HttpGet]
        public IActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeneyimEkle(Deneyim deneyim)
        {
            if (ModelState.IsValid)
            {
                db.Deneyims.Add(deneyim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deneyim);
        }
        [HttpGet]
        public IActionResult DeneyimSil(int id)
        {
            var deneyim = db.Deneyims.Find(id);
            if (deneyim != null)
            {
                db.Deneyims.Remove(deneyim);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeneyimGuncelle(int id)
        {
            var deneyim = db.Deneyims.Find(id);
            if (deneyim == null)
            {
                return NotFound();
            }
            return View(deneyim);
        }
        [HttpPost]
        public async Task<IActionResult> DeneyimGuncelle(Deneyim deneyim)
        {
            if (ModelState.IsValid)
            {
                db.Deneyims.Update(deneyim);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(deneyim);
        }
    }
}
