using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia p)
        {
            p.Status = true;
           socialMediaManager.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = socialMediaManager.TGetByID(id);
         
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia SocialMedia)
        {
            
            socialMediaManager.TUpdate(SocialMedia);
            return RedirectToAction("Index");
        }

    }
}
