using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAnnouncement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : Controller
    {
        AnnouncementManager AnnouncementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = AnnouncementManager.TGetList().OrderByDescending(x=>x.Date).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement Announcement)
        {
            Announcement.Status = "Aktif";
            Announcement.Date = DateTime.Now;
            AnnouncementManager.TAdd(Announcement);
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int id)
        {

            var values = AnnouncementManager.TGetByID(id);
            AnnouncementManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement = AnnouncementManager.TGetByID(id);
            return View(announcement);
        }
    }
}
