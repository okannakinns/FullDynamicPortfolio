using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class Last4ContactMessages:ViewComponent
    {
        Context c =new Context();
        private readonly UserManager<WriterUser> userManager;

        public Last4ContactMessages(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var user= await userManager.FindByNameAsync(User.Identity.Name);
            string email = user.Email; 
            var values =c.Messages.OrderByDescending(x=>x.Date).Take(4).ToList();
            return View(values); 
        }
    }
}
