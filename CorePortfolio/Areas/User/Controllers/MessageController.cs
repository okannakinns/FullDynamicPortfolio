using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class MessageController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
           
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var messageList = writerMessageManager.GetListReceiverMessages(p).OrderByDescending(x=>x.Date).ToList();
            return View(messageList);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var messageList = writerMessageManager.GetListSenderMessages(p).OrderByDescending(x => x.Date).ToList();
            return View(messageList);
        }

        [HttpGet]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetByID(id);
           
            return View(message);
        }

        [HttpGet]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage message = writerMessageManager.TGetByID(id);

            return View(message);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(WriterMessage p)
        {
            Context c = new Context();

            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver=c.Users.Where(x => x.Email == p.Receiver).FirstOrDefault();
            p.ReceiverName = receiver.Name+" "+receiver.SurName;
            p.Sender = sender.Email;
            p.SenderName = sender.Name+" "+sender.SurName;
            p.Date= DateTime.Now;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage","Message");
        }
    }
}
