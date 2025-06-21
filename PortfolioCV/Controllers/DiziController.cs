using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class DiziController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var diziler = db.Dizis.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                diziler = diziler.Where(f => f.Ad.Contains(search));

            var pagedList = diziler
                .OrderByDescending(f => f.DiziId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult DiziEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DiziEkle(Dizi dizi)
        {
            if (ModelState.IsValid)
            {
                db.Dizis.Add(dizi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dizi);
        }
        [HttpGet]
        public IActionResult DiziSil(int id)
        {
            var dizi = db.Dizis.Find(id);
            if (dizi != null)
            {
                db.Dizis.Remove(dizi);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DiziGuncelle(int id)
        {
            var dizi = db.Dizis.Find(id);
            if (dizi == null)
            {
                return NotFound();
            }
            return View(dizi);
        }
        [HttpPost]
        public async Task<IActionResult> DiziGuncelle(Dizi dizi)
        {
            if (ModelState.IsValid)
            {
                db.Dizis.Update(dizi);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dizi);
        }
    }
}
