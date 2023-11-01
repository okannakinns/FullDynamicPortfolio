using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserListController : Controller
    {
       Context c = new Context();
        public IActionResult Index()
        {
            var values = c.Users.ToList();
            return View(values);
        }


        public IActionResult Delete(int id)
        {

            var values = c.Users.Find(id);
            c.Users.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
