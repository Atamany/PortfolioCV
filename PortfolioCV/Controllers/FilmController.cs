using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    public class FilmController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var filmler = db.Films.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                filmler = filmler.Where(f => f.Ad.Contains(search));

            var pagedList = filmler
                .OrderByDescending(f => f.FilmId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult FilmEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FilmEkle(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }
        [HttpGet]
        public IActionResult FilmSil(int id)
        {
            var film = db.Films.Find(id);
            if (film != null)
            {
                db.Films.Remove(film);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult FilmGuncelle(int id)
        {
            var film = db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }
        [HttpPost]
        public async Task<IActionResult> FilmGuncelle(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Update(film);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(film);
        }
    }
}
