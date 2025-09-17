using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet] 
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetMembers(string id)
        {
            var user = context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }

}
