using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class PodcastController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var podcastler = db.Podcasts.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                podcastler = podcastler.Where(f => f.BolumAd.Contains(search));

            var pagedList = podcastler
                .OrderByDescending(f => f.PodcastId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult PodcastEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PodcastEkle(Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Podcasts.Add(podcast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podcast);
        }
        [HttpGet]
        public IActionResult PodcastSil(int id)
        {
            var podcast = db.Podcasts.Find(id);
            if (podcast != null)
            {
                db.Podcasts.Remove(podcast);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult PodcastGuncelle(int id)
        {
            var podcast = db.Podcasts.Find(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return View(podcast);
        }
        [HttpPost]
        public async Task<IActionResult> PodcastGuncelle(Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                db.Podcasts.Update(podcast);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(podcast);
        }
    }
}
