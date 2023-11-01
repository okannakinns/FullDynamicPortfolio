using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreExperience.ViewComponents.Experience
{
    public class SendMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        
        public IViewComponentResult Invoke()
        {

            return View();
        }
       

    }
}
