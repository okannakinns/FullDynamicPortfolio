using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreContact.ViewComponents.Contact
{
    public class FeatureStatistics : ViewComponent
    {
        Context c =new Context();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            ViewBag.ServiceCount = c.Services.Count();
            ViewBag.ReferanceCount = c.Testimonials.Count();
            ViewBag.AnnouncementCount =c.Announcements.Count();
            ViewBag.SkillCount =c.Skills.Count();
            return View();
        }
    }
}
