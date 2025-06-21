using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class MakaleController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var makaleler = db.Makales.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                makaleler = makaleler.Where(f => f.Baslik.Contains(search));

            var pagedList = makaleler
                .OrderByDescending(f => f.MakaleId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult MakaleEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakaleEkle(Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makales.Add(makale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }
        [HttpGet]
        public IActionResult MakaleSil(int id)
        {
            var makale = db.Makales.Find(id);
            if (makale != null)
            {
                db.Makales.Remove(makale);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MakaleGuncelle(int id)
        {
            var makale = db.Makales.Find(id);
            if (makale == null)
            {
                return NotFound();
            }
            return View(makale);
        }
        [HttpPost]
        public async Task<IActionResult> MakaleGuncelle(Makale makale)
        {
            if (ModelState.IsValid)
            {
                db.Makales.Update(makale);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(makale);
        }
    }
}
