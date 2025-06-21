using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class SertifikaController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var sertifikalar = db.Sertifikas.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                sertifikalar = sertifikalar.Where(f => f.Ad.Contains(search));

            var pagedList = sertifikalar
                .OrderByDescending(f => f.SertifikaId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SertifikaEkle(Sertifika sertifika)
        {
            if (ModelState.IsValid)
            {
                db.Sertifikas.Add(sertifika);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sertifika);
        }
        [HttpGet]
        public IActionResult SertifikaSil(int id)
        {
            var sertifika = db.Sertifikas.Find(id);
            if (sertifika != null)
            {
                db.Sertifikas.Remove(sertifika);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SertifikaGuncelle(int id)
        {
            var sertifika = db.Sertifikas.Find(id);
            if (sertifika == null)
            {
                return NotFound();
            }
            return View(sertifika);
        }
        [HttpPost]
        public async Task<IActionResult> SertifikaGuncelle(Sertifika sertifika)
        {
            if (ModelState.IsValid)
            {
                db.Sertifikas.Update(sertifika);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sertifika);
        }
    }
}
