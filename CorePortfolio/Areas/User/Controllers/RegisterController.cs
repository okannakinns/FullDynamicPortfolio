using CorePortfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
          
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    SurName = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName

                };

            if (p.Password == p.ConfirmPassword)
            {
                var result= await _userManager.CreateAsync(w, p.Password);
           
               
             if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(w, "User");
                    return RedirectToAction("Index","Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
