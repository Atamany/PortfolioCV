using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class TiyatroController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var tiyatrolar = db.Tiyatros.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                tiyatrolar = tiyatrolar.Where(f => f.Ad.Contains(search));

            var pagedList = tiyatrolar
                .OrderByDescending(f => f.TiyatroId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult TiyatroEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TiyatroEkle(Tiyatro tiyatro)
        {
            if (ModelState.IsValid)
            {
                db.Tiyatros.Add(tiyatro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiyatro);
        }
        [HttpGet]
        public IActionResult TiyatroSil(int id)
        {
            var tiyatro = db.Tiyatros.Find(id);
            if (tiyatro != null)
            {
                db.Tiyatros.Remove(tiyatro);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult TiyatroGuncelle(int id)
        {
            var tiyatro = db.Tiyatros.Find(id);
            if (tiyatro == null)
            {
                return NotFound();
            }
            return View(tiyatro);
        }
        [HttpPost]
        public async Task<IActionResult> TiyatroGuncelle(Tiyatro tiyatro)
        {
            if (ModelState.IsValid)
            {
                db.Tiyatros.Update(tiyatro);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tiyatro);
        }
    }
}
