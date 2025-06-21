using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class SosyalController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var sosyaller = db.Sosyals.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                sosyaller = sosyaller.Where(f => f.Platform.Contains(search));

            var pagedList = sosyaller
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult SosyalEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SosyalEkle(Sosyal sosyal)
        {
            if (ModelState.IsValid)
            {
                db.Sosyals.Add(sosyal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sosyal);
        }
        [HttpGet]
        public IActionResult SosyalSil(int id)
        {
            var sosyal = db.Sosyals.Find(id);
            if (sosyal != null)
            {
                db.Sosyals.Remove(sosyal);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SosyalGuncelle(int id)
        {
            var sosyal = db.Sosyals.Find(id);
            if (sosyal == null)
            {
                return NotFound();
            }
            return View(sosyal);
        }
        [HttpPost]
        public async Task<IActionResult> SosyalGuncelle(Sosyal sosyal)
        {
            if (ModelState.IsValid)
            {
                db.Sosyals.Update(sosyal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sosyal);
        }
    }
}
