using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().OrderByDescending(x=>x.CreationDate).ToList();
            return View(values);
        }
    }
}
