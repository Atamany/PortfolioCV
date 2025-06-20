using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    public class KitapController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var kitaplar = db.Kitaps.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                kitaplar = kitaplar.Where(f => f.Ad.Contains(search));

            var pagedList = kitaplar
                .OrderByDescending(f => f.KitapId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult KitapEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KitapEkle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                db.Kitaps.Add(kitap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitap);
        }
        [HttpGet]
        public IActionResult KitapSil(int id)
        {
            var kitap = db.Kitaps.Find(id);
            if (kitap != null)
            {
                db.Kitaps.Remove(kitap);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult KitapGuncelle(int id)
        {
            var kitap = db.Kitaps.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }
        [HttpPost]
        public async Task<IActionResult> KitapGuncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                db.Kitaps.Update(kitap);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kitap);
        }
    }
}
