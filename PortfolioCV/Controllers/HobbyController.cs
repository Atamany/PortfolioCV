using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.Controllers
{
    public class HobbyController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IActionResult Film()
        {
            var degerler = db.Films.OrderByDescending(x=>x.FilmId).ToList();
            return View(degerler);
        }
        public IActionResult Dizi()
        {
            var degerler = db.Dizis.OrderByDescending(x=>x.DiziId).ToList();
            return View(degerler);
        }
        public IActionResult Kitap()
        {
            var degerler = db.Kitaps.OrderByDescending(x=>x.KitapId).ToList();
            return View(degerler);
        }
        public IActionResult Podcast()
        {
            var degerler = db.Podcasts.OrderByDescending(x=>x.PodcastId).ToList();
            return View(degerler);
        }
        public IActionResult YouTube()
        {
            var degerler = db.YouTubes.OrderByDescending(x=>x.YouTubeId).ToList();
            return View(degerler);
        }
        public IActionResult Tiyatro()
        {
            var degerler = db.Tiyatros.OrderByDescending(x=>x.TiyatroId).ToList();
            return View(degerler);
        }
    }
}
