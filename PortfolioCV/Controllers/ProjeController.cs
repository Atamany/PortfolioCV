using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class ProjeController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var projeler = db.Projes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                projeler = projeler.Where(f => f.Baslik.Contains(search));

            var pagedList = projeler
                .OrderByDescending(f => f.ProjeId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkle(Proje proje)
        {
            if (ModelState.IsValid)
            {
                db.Projes.Add(proje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proje);
        }
        [HttpGet]
        public IActionResult ProjeSil(int id)
        {
            var proje = db.Projes.Find(id);
            if (proje != null)
            {
                db.Projes.Remove(proje);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ProjeGuncelle(int id)
        {
            var proje = db.Projes.Find(id);
            if (proje == null)
            {
                return NotFound();
            }
            return View(proje);
        }
        [HttpPost]
        public async Task<IActionResult> ProjeGuncelle(Proje proje)
        {
            if (ModelState.IsValid)
            {
                db.Projes.Update(proje);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(proje);
        }
    }
}
