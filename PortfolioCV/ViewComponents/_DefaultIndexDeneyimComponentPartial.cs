using Microsoft.AspNetCore.Mvc;
using PortfolioCV.DAL.Context;

namespace PortfolioCV.ViewComponents
{
    public class _DefaultIndexDeneyimComponentPartial : ViewComponent
    {
        PortfolioCVContext db = new PortfolioCVContext();
        public IViewComponentResult Invoke()
        {
            var deger = db.Deneyims.OrderByDescending(x => x.DeneyimId).ToList();
            return View(deger);
        }
    }
}
