using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class ProjectStatusChart:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Status1= c.Portfolios.Where(x => x.Status == "Tamamlandı").Count();
            ViewBag.Status2 = c.Portfolios.Where(x => x.Status == "Devam Ediyor").Count();
            ViewBag.Status3 = c.Portfolios.Where(x => x.Status == "Plan Aşamasında").Count();

            return View();
        }
    }
}
