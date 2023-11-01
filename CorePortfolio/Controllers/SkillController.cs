using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager=new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            var values=skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            skill.CreationDate = DateTime.Now;
            skill.UpdatedDate = DateTime.Now;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values=skillManager.TGetByID(id);
            skillManager.TDelete(values);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            skill.UpdatedDate = DateTime.Now;
           skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
