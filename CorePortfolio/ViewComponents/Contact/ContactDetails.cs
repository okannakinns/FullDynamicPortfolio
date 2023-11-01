using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreContact.ViewComponents.Contact
{
    public class ContactDetails : ViewComponent
    {
        ContactManager ContactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var values = ContactManager.TGetList();
            return View(values);
        }
    }
}
