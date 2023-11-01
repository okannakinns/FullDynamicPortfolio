using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
   [Area("User")]
    [Authorize(Roles = "User")]
    public class DefaultController : Controller
    {
        AnnouncementManager AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values= AnnouncementManager.TGetList().OrderByDescending(x => x.Date).ToList();
            return View(values);
        }
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement  = AnnouncementManager.TGetByID(id);
            return View(announcement);
        }


        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
    }
}
