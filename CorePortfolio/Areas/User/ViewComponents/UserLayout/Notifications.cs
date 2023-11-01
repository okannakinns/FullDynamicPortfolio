using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.ViewComponents.UserLayout
{
    public class Notifications : ViewComponent
    {
        WriterMessageManager WriterMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        UserManager<WriterUser> _userManager;

        public Notifications(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user=await _userManager.FindByNameAsync(User.Identity.Name);
            var values = WriterMessageManager.GetListReceiverMessages(user.Email).OrderByDescending(x => x.Date).Take(3).ToList();
            return View(values);
        }
    }
}
