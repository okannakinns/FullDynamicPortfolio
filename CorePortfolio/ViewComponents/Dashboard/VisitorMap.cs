using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class VisitorMap:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
