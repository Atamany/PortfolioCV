using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;
using System.Security.Claims;

namespace PortfolioCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        PortfolioCVContext db = new PortfolioCVContext();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = db.Admins.FirstOrDefault(x => x.Email == username.ToLower());
            if (account == null || account.Password != password)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            else
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username.ToLower())};
                SetCookie("AccountID", account.AdminId);
                var identity = new ClaimsIdentity(claims, "AccountID");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AccountID", principal);

                return RedirectToAction("Index", "Admin");
            }
        }
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("AccountID");
            await HttpContext.SignOutAsync("AccountID");
            return RedirectToAction("Login", "Login");
        }

        private void SetCookie(string key, int value, int? expireTime = null)
        {
            var option = new CookieOptions
            {
                Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append(key, value.ToString(), option);
        }
    }
}