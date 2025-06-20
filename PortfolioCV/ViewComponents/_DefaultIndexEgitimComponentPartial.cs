using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.ViewComponents
{
    public class _DefaultIndexEgitimComponentPartial : ViewComponent
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IViewComponentResult Invoke()
        {
            var deger = db.Egitims.OrderByDescending(x => x.EgitimId).ToList();
            return View(deger);
        }
    }
}
