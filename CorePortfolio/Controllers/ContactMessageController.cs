using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values= messageManager.TGetList().OrderByDescending(x=>x.Date).ToList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var values=messageManager.TGetByID(id);
            messageManager.TDelete(values);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ContactMessageDetails(int id)
        {
            var values=messageManager.TGetByID(id);    
            return View(values);
        }
    }
}
