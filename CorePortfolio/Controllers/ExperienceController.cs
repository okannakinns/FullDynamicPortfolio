using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager exManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var values = exManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experience.CreationDate = DateTime.Now;
            experience.UpdatedDate = DateTime.Now;
            exManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values=exManager.TGetByID(id);
            exManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values=exManager.TGetByID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experience.UpdatedDate = DateTime.Now;
            exManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

    }
}
