using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetMembers(string id)
        {
            var user = context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }

}
