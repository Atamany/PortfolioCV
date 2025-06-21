using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class YouTubeController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var kanallar = db.YouTubes.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                kanallar = kanallar.Where(f => f.Kanal.Contains(search));

            var pagedList = kanallar
                .OrderByDescending(f => f.YouTubeId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult YouTubeEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YouTubeEkle(YouTube youtube)
        {
            if (ModelState.IsValid)
            {
                db.YouTubes.Add(youtube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(youtube);
        }
        [HttpGet]
        public IActionResult YouTubeSil(int id)
        {
            var youtube = db.YouTubes.Find(id);
            if (youtube != null)
            {
                db.YouTubes.Remove(youtube);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult YouTubeGuncelle(int id)
        {
            var youtube = db.YouTubes.Find(id);
            if (youtube == null)
            {
                return NotFound();
            }
            return View(youtube);
        }
        [HttpPost]
        public async Task<IActionResult> YouTubeGuncelle(YouTube youtube)
        {
            if (ModelState.IsValid)
            {
                db.YouTubes.Update(youtube);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(youtube);
        }
    }
}
