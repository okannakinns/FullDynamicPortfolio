using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CorePortfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class DashboardController : Controller
    {
        Context c = new Context();
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                ViewBag.User =user.Name+" "+ user.SurName+" ";
            }
            //statistics

            ViewBag.AnnouncementCount = c.Announcements.Count();
            ViewBag.ReceiverMessagesCount = c.WriterMessages.Where(x => x.Receiver ==user.Email).Count();
            ViewBag.SenderMessagesCount = c.WriterMessages.Where(x => x.Sender == user.Email).Count();
            ViewBag.TotalMessagesCount = ViewBag.ReceiverMessagesCount + ViewBag.SenderMessagesCount;

            // Weather API

            string api = "9067e94a8356ff36c3b0efe903224354";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.WeatherInfo = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            
            return View();
        }
    }
}
