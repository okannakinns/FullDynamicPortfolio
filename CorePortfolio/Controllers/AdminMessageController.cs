using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        Context c = new Context();
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public AdminMessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessageList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string p = user.Email;
            var values = writerMessageManager.GetListReceiverMessages(p).OrderByDescending(x => x.Date).ToList(); ;
            return View(values);
        }
        public async Task<IActionResult> SenderMessageList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string p = user.Email;
            var values = writerMessageManager.GetListSenderMessages(p).OrderByDescending(x => x.Date).ToList(); ;
            return View(values);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
           var value = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(value);
            return RedirectToAction("ReceiverMessageList","AdminMessage");
        }

        [HttpGet]

        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage message=writerMessageManager.TGetByID(id);
            return View(message);
        }
        [HttpGet]

        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetByID(id);
            return View(message);
        }
        [HttpGet]
        public IActionResult CreateNewMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewMessage(WriterMessage p)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver=c.Users.Where(u => u.Email == p.Receiver).FirstOrDefault();
            p.Date=DateTime.Now;
            p.Sender = sender.Email;
            p.SenderName = sender.Name + " " + sender.SurName;
            p.Receiver = receiver.Email;
            p.ReceiverName = receiver.Name+ " " + receiver.SurName;
            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessageList","AdminMessage");
        }
    }
}
