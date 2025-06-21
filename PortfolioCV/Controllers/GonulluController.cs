using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class GonulluController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index()
        {
            var gonulluler = db.Gonullus.OrderByDescending(x => x.GonulluId).ToList();
            return View(gonulluler);
        }
        [HttpGet]
        public IActionResult GonulluEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GonulluEkle(Gonullu gonullu)
        {
            if (ModelState.IsValid)
            {
                db.Gonullus.Add(gonullu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gonullu);
        }
        [HttpGet]
        public IActionResult GonulluSil(int id)
        {
            var gonullu = db.Gonullus.Find(id);
            if (gonullu != null)
            {
                db.Gonullus.Remove(gonullu);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GonulluGuncelle(int id)
        {
            var gonullu = db.Gonullus.Find(id);
            if (gonullu == null)
            {
                return NotFound();
            }
            return View(gonullu);
        }
        [HttpPost]
        public async Task<IActionResult> GonulluGuncelle(Gonullu gonullu)
        {
            if (ModelState.IsValid)
            {
                db.Gonullus.Update(gonullu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gonullu);
        }
    }
}
