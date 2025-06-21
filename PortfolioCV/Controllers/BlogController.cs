using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using PortfolioCV.DAL.Entities;
using X.PagedList.Extensions;

namespace PortfolioCV.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Index(int page = 1, string search = "")
        {
            var bloglar = db.Blogs.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                bloglar = bloglar.Where(f => f.Baslik.Contains(search));

            var pagedList = bloglar
                .OrderByDescending(f => f.BlogId)
                .ToPagedList(page, 20);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult BlogEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogEkle(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
        [HttpGet]
        public IActionResult BlogSil(int id)
        {
            var blog = db.Blogs.Find(id);
            if (blog != null)
            {
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult BlogGuncelle(int id)
        {
            var blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> BlogGuncelle(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Update(blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
    }
}
