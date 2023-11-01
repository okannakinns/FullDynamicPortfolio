using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.ViewComponents.Dashboard
{
    public class ToDoListSection:ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EfToDoListDal());
        public IViewComponentResult Invoke()
        {
            var values = toDoListManager.TGetList();
            return View(values);
        }
    }
}
