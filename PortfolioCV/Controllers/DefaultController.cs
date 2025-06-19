using Microsoft.AspNetCore.Mvc;

namespace PortfolioCV.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Proje()
        {
            return View();
        }
        public IActionResult Sosyal()
        {
            return View();
        }
        public IActionResult Makale()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Referanslar()
        {
            return View();
        }
        public IActionResult Sertifikalar()
        {
            return View();
        }
    }
}
