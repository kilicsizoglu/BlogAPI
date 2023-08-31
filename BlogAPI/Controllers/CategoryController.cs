using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogAPI;

[Route("api/{controller}")]
public class CategoryController : Controller
{

    public BlogDbContext blogDbContext;
    public CategoryController(BlogDbContext _context) {
        blogDbContext = _context;
    }

    [HttpGet]
    public IActionResult Get([FromBody] Guid key, [FromBody] Guid Id) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            Category? category = blogDbContext.categories.ToList().Where(x => x.Id == Id).FirstOrDefault();
            return Ok(category);
        }
    }

    [HttpGet]
    public IActionResult GetAll([FromBody] Guid key) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            List<Category>? categorys = blogDbContext.categories.ToList();
            return Ok(categorys);
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] Guid key, [FromBody] Category category) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            if (category == null) {
                return Ok("reject");
            } else {
                blogDbContext.categories.Add(category);
                return Ok(category);
            }
        }
    }

    [HttpPut]
    public IActionResult Delete([FromBody] Guid key, [FromBody] Guid Id) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            Category? category1 = blogDbContext.categories.ToList().Where(x => x.Id == Id).FirstOrDefault();
            if (category1 == null) {
                return Ok("reject");
            } else {
                blogDbContext.categories.Remove(category1);
                return Ok(category1);
            }
        }
    }

    [HttpPatch]
    public IActionResult Edit([FromBody] Guid key, [FromBody] Category category) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            Category? category1 = blogDbContext.categories.ToList().Where(x => x.Id == category.Id).FirstOrDefault();
            if (category1 == null) {
                return Ok("reject");
            } else {
                return Ok(category1);
            }
        }
    }

}
