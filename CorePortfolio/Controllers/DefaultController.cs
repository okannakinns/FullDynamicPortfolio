using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CorePortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message msg)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            msg.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            msg.Status = true;
            messageManager.TAdd(msg);
            return PartialView();
        }
    }
}
