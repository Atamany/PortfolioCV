using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.ViewComponents
{
    public class _DefaultIndexGonulluComponentPartial : ViewComponent
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IViewComponentResult Invoke()
        {
            var deger = db.Gonullus.OrderByDescending(x => x.GonulluId).ToList();
            return View(deger);
        }

    }
}
