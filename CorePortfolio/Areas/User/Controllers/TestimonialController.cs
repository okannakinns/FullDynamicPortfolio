using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
    [Authorize(Roles ="User")]
    [Area("User")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        private readonly UserManager<WriterUser> _userManager;

        public TestimonialController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var name = user.Name + " " + user.SurName;
            var value = testimonialManager.TGetList().Where(x => x.ClientName == name).FirstOrDefault();

            return View(value);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(value);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var name = user.Name + " " + user.SurName;
            ViewBag.NameAndSurname = name;
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = testimonialManager.TGetByID(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult TestimonialDetails(int id)
        {
            Testimonial testimonial = testimonialManager.TGetByID(id);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(Testimonial testimonial)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            testimonial.ClientName= user.Name + " " + user.SurName;
            testimonial.CreationDate = DateTime.Now;
            testimonial.ImageUrl = "/Template/images/testimonials/userpic.png";
            testimonialManager.TAdd(testimonial);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            testimonial.UpdatedDate = DateTime.Now;
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
