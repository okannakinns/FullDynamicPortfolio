using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var values= serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            service.CreationDate = DateTime.Now;
            service.UpdatedDate = DateTime.Now;
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = serviceManager.TGetByID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            service.UpdatedDate = DateTime.Now;
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

    }
}
