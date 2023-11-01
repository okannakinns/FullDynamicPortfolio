using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values=c.Portfolios.OrderByDescending(msg => msg.CreationDate)
            .Take(5)
            .ToList();
            ViewBag.ProjectCount=c.Portfolios.Count();
            return View(values);
        }
    }
}
