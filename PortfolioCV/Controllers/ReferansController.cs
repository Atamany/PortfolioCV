using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class ReferansController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var referanslar = db.Referanss.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                referanslar = referanslar.Where(f => f.AdSoyad.Contains(search));

            var pagedList = referanslar
                .OrderByDescending(f => f.ReferansId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult ReferansEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReferansEkle(Referans makale)
        {
            if (ModelState.IsValid)
            {
                db.Referanss.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }
        [HttpGet]
        public IActionResult ReferansSil(int id)
        {
            var makale = db.Referanss.Find(id);
            if (makale != null)
            {
                db.Referanss.Remove(makale);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ReferansGuncelle(int id)
        {
            var makale = db.Referanss.Find(id);
            if (makale == null)
            {
                return NotFound();
            }
            return View(makale);
        }
        [HttpPost]
        public async Task<IActionResult> ReferansGuncelle(Referans makale)
        {
            if (ModelState.IsValid)
            {
                db.Referanss.Update(makale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(makale);
        }
    }
}
