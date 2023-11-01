using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = aboutManager.TGetByID(3);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
