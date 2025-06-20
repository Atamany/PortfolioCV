using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.Controllers
{
    public class SettingsController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MailGuncelle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MailGuncelle(string OldMail, string NewMail, string NewMail2)
        {
            string id = Request.Cookies["AccountID"];
            var accountId = int.Parse(id);
            var account = db.Admins.Find(accountId);
            if (NewMail.ToLower() == NewMail2.ToLower())
            {
                if (OldMail.ToLower() == account.Email.ToLower())
                {
                    account.Email = NewMail.ToLower();
                    db.SaveChanges();
                    return RedirectToAction("Logout", "Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Eski şifre hatalı.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Yeni şifreler uyuşmuyor.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult SifreGuncelle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SifreGuncelle(string OldPassword, string NewPassword, string NewPassword2)
        {
            string id = Request.Cookies["AccountID"];
            var accountId = int.Parse(id);
            var account = db.Admins.Find(accountId);
            if (NewPassword == NewPassword2)
            {
                if (OldPassword == account.Password)
                {
                    account.Password = NewPassword;
                    db.SaveChanges();
                    return RedirectToAction("Logout", "Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Eski şifre hatalı.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Yeni şifreler uyuşmuyor.";
                return View();
            }
        }
    }
}
