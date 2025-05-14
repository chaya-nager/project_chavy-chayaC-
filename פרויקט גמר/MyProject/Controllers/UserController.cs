using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IContext _context;

        public UserController(IContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(User value)
        {  // שמירה למסד הנתונים
                _context.Users.Add(value);
                _context.Save();   
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch.");
            }
            var userUpdate = await _context.Users.FindAsync(id);
            if (userUpdate == null)
            {
                return NotFound();
            }
            userUpdate.FullName = user.FullName;
            userUpdate.Email = user.Email;
            userUpdate.PasswordHash = user.PasswordHash;
            userUpdate.BirthDate = user.BirthDate;
            userUpdate.UserType = user.UserType;
            userUpdate.HealthConditions = user.HealthConditions;
            await _context.Save();
            return NoContent(); 
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.Save();
            return NoContent(); // מחזיר 204 בלי תוכן
        }
    }
}
