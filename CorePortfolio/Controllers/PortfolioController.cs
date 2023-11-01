using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager pfManager= new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            var values= pfManager.TGetList().OrderByDescending(x=>x.CreationDate).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portfolio.UpdatedDate = DateTime.Now;
            portfolio.CreationDate = DateTime.Now;
            pfManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            
            var values = pfManager.TGetByID(id);
            pfManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            
            var values = pfManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
           
            portfolio.UpdatedDate = DateTime.Now;
            pfManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }

    }
}
