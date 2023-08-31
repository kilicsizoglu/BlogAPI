using Microsoft.AspNetCore.Mvc;

namespace BlogAPI;

[Route("api/{controller}")]
public class AuthController : Controller
{
    public BlogDbContext blogDbContext;
    public AuthController(BlogDbContext _context) {
        blogDbContext = _context;
    }

    public IActionResult Login([FromBody] String Name, [FromBody] String Password) {
        User? user = blogDbContext.users.ToList().Where(u => u.Name == Name && u.Password == Password).FirstOrDefault();
        if (user == null) {
            return Ok("reject");
        }else {
            Guid key = Guid.NewGuid();
            blogDbContext.apikeys.Add(new APIKey(key, user.Id));
            return Ok(key);
        }
    }

    public IActionResult Logout([FromBody] Guid Key) {
        APIKey? apikey = blogDbContext.apikeys.ToList().Where(u => u.Key == Key).FirstOrDefault();
        if (apikey == null) {
            return View("reject");
        } else {
            blogDbContext.apikeys.Remove(apikey);
            return View("ok");
        }
    }
}
