using CorePortfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]

    public class ProfileSettingsController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileSettingsController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.SurName;
           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index( UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = p.Name;
            user.SurName = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
           
           var result= await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
