using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values=testimonialManager.TGetList();

            return View(values);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value=testimonialManager.TGetByID(id);
            testimonialManager.TDelete(value);

            return RedirectToAction("Index");
        }
     
        
        [HttpGet]
        public IActionResult TestimonialDetails(int id)
        {
            Testimonial testimonial = testimonialManager.TGetByID(id);
            return View(testimonial);
        }
        
    }
}
