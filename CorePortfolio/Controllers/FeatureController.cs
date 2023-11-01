using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager fManager = new FeatureManager(new EfFeatureDal());
        
        [HttpGet]
        public IActionResult Index()
        {
            
            var values = fManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature feature)
        {
            
            fManager.TUpdate(feature);


            return RedirectToAction("Index","Default");
        }
    }
}
