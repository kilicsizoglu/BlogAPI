using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogAPI;

[Route("api/{controllers}")]
public class BlogControllers : Controller
{
    public BlogDbContext blogDbContext;
    public BlogControllers(BlogDbContext _context) {
        blogDbContext = _context;
    }

    [HttpGet]
    public IActionResult Get([FromBody] Guid key) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            List<BlogMessage>? blogMessages = blogDbContext.blogMessages.ToList();
            return Ok(blogMessages);
        }
    }

    [HttpGet]
    public IActionResult Get([FromBody] Guid key, [FromBody] Guid Id) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            BlogMessage? blogMessage = blogDbContext.blogMessages.ToList().FirstOrDefault(x => x.Id == Id);
            return Ok(blogMessage);
        }
    }

    [HttpPost]
    public IActionResult Add([FromBody] Guid key, [FromBody] BlogMessage blogMessage) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            blogDbContext.blogMessages.Add(blogMessage);
            return Ok("ok...");
        }
    }

    [HttpPatch]
    public IActionResult Edit([FromBody] Guid key, [FromBody] BlogMessage blogMessage) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            blogDbContext.blogMessages.Update(blogMessage);
            return Ok("ok...");
        }
    }

    [HttpPut]
    public IActionResult Delete([FromBody] Guid key, [FromBody] BlogMessage blogMessage) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(x => x.Key == key).FirstOrDefault();
        if (apikey == null) {
            return Ok("reject");
        } else {
            blogDbContext.blogMessages.Remove(blogMessage);
            return Ok("ok...");
        }
    }

}
