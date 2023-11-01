using CorePortfolio.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
   
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;
        

        public LoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                
                

                if (result.Succeeded)
                {
                    return RedirectToAction("UserControl", "Login");
                    

                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı Veya Şifre");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> UserControl()
        {
            if(_signInManager.IsSignedIn(User))
            {

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "Default" });
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
               
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

    }
}
