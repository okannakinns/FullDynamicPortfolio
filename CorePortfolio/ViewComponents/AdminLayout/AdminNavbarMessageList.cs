using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.AdminLayout
{
    public class AdminNavbarMessageList : ViewComponent
    {
        UserManager<WriterUser> _userManager;

        Context c = new Context();
        public AdminNavbarMessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = c.WriterMessages.Where(x => x.Date.Day == DateTime.Now.Day && x.Receiver == user.Email).OrderByDescending(x => x.Date).ToList();
            ViewBag.TotalMessages = c.WriterMessages.Where(x => x.Receiver == user.Email).Count();
            return View(values);
        }
    }
}
