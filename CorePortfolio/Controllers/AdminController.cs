using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public AdminController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public PartialViewResult AdminHeadPartial()
        {
            return PartialView();
        }
        public async Task<PartialViewResult> AdminSidebarPartial()
        {
            
            return PartialView();
        }
        public async Task<PartialViewResult> AdminNavbarPartial()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = user.Name + " " + user.SurName;
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptsPartial()
        {
            return PartialView();
        }
    }
}
