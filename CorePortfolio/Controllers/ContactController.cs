using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager ContactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = ContactManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact Contact)
        {
            ContactManager.TUpdate(Contact);
            return RedirectToAction("Index", "Default");
        }
        [HttpPost]
        public IActionResult SendMessage(Message p)
        {
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            messageManager.TAdd(p);
            return RedirectToAction("Index","Default");
        }
    }
}
