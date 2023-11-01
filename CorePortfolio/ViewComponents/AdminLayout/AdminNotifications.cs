using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.AdminLayout
{
    public class AdminNotifications:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Testimonials=c.Testimonials.Where(t=>t.CreationDate.Day==DateTime.Now.Day).Count();
            ViewBag.ContactMessages=c.Messages.Where(t=>t.Date.Day==DateTime.Now.Day).Count();
            return View();
        }
    }
}
