using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class ProjectSlider : ViewComponent
    {
        PortfolioManager pManager = new PortfolioManager(new EfPortfolioDal());
        UserManager<WriterUser> _userManager;

        public ProjectSlider(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserEmail = user.Email;
            ViewBag.UserName = user.Name+" "+user.SurName;
            var values = pManager.TGetList();
            return View(values);
        }
    }
}
