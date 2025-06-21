using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index()
        {
            var egitimler = db.Egitims.OrderByDescending(x=>x.EgitimId).ToList();
            return View(egitimler);
        }
        [HttpGet]
        public IActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EgitimEkle(Egitim egitim)
        {
            if (ModelState.IsValid)
            {
                db.Egitims.Add(egitim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(egitim);
        }
        [HttpGet]
        public IActionResult EgitimSil(int id)
        {
            var egitim = db.Egitims.Find(id);
            if (egitim != null)
            {
                db.Egitims.Remove(egitim);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EgitimGuncelle(int id)
        {
            var egitim = db.Egitims.Find(id);
            if (egitim == null)
            {
                return NotFound();
            }
            return View(egitim);
        }
        [HttpPost]
        public async Task<IActionResult> EgitimGuncelle(Egitim egitim)
        {
            if (ModelState.IsValid)
            {
                db.Egitims.Update(egitim);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(egitim);
        }
    }
}
