using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        UserManager<WriterUser> _userManager;
        WriterMessageManager writerMessageManager = new(new EfWriterMessageDal());

        public StatisticsDashboard2(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReceiverMsg=writerMessageManager.GetListReceiverMessages(user.Email).Count();
            ViewBag.TodayReceiverMsg=c.WriterMessages.Where(x=>x.Date.Day==DateTime.Now.Day &&x.Receiver==user.Email).Count();
            ViewBag.TodayContactMsg=c.Messages.Where(x=>x.Date.Day==DateTime.Now.Day).Count();
            ViewBag.SenderMsg = writerMessageManager.GetListSenderMessages(user.Email).Count();
            ViewBag.ContactMsg = c.Messages.Count();
            return View();
        }
    }
}
