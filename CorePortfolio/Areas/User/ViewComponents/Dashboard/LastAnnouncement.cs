using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.ViewComponents.Dashboard
{
    public class LastAnnouncement : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var value = announcementManager.TGetList().OrderByDescending(x => x.Date).Take(1).FirstOrDefault();
            return View(value);
        }
    }
}
