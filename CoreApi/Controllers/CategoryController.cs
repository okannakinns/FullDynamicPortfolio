using CoreApi.DAL.ApiContext;
using CoreApi.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList()) ;
        }
        [HttpGet("{id}")]
        public IActionResult IdGet(int id)
        {
            using var c = new Context();
            var value=c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p) 
        {
            using var c = new Context();
            c.Categories.Add(p);
            c.SaveChanges();
            return Created("",c);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value=c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges() ;
                return NoContent() ;
            }

        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p) 
        {
            using var c = new Context();
            var value=c.Find<Category>(p.CategoryID);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
               value.CategoryName=p.CategoryName;
                c.Update(value);
                c.SaveChanges() ;
                return NoContent() ;
            }
        }
    }
}
