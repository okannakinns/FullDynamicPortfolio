using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.AdminLayout
{

    public class SidebarAdminInfo:ViewComponent
    {
        UserManager<WriterUser> _userManager;

        public SidebarAdminInfo(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = user.Name + " " + user.SurName;
            ViewBag.UserName = user.UserName;
            return View();
        }
    }
}
