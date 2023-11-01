using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreExperience.ViewComponents.Dashboard
{
    public class DashboardExperience : ViewComponent
    {
        ExperienceManager exManager = new ExperienceManager(new EfExperienceDal());
        public IViewComponentResult Invoke()
        {
            var values= exManager.TGetList();
            return View(values);
        }
    }
}
