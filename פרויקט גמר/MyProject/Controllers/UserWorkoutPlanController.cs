using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutPlanController : ControllerBase
    {
        private readonly IContext _context;

        public UserWorkoutPlanController(IContext context)
        {
            _context = context;
        }
        // GET: api/<UserWorkoutPlanController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWorkoutPlan>>> GetUserWorkoutPlans()
        {
            return await _context.UserWorkoutPlans.ToListAsync();
        }

        // GET api/<UserWorkoutPlanController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWorkoutPlan>> GetUserById(int id)
        {
            var userWorkoutPlan = await _context.UserWorkoutPlans.FindAsync(id);
            if (userWorkoutPlan == null)
            {
                return NotFound();
            }
            return userWorkoutPlan;
        }
        // POST api/<UserWorkoutPlanController>
        [HttpPost]
        public void Post(UserWorkoutPlan userWorkoutPlan)
        {  // שמירה למסד הנתונים
            _context.UserWorkoutPlans.Add(userWorkoutPlan);
            _context.SaveChangesAsync();
        }


        // PUT api/<UserWorkoutPlanController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserWorkoutPlan(int id, [FromBody] UserWorkoutPlan userWorkoutPlan)
        {
            if (id != userWorkoutPlan.Id)
                return BadRequest("ID mismatch.");
            var userWorkoutPlanUpdate = await _context.UserWorkoutPlans.FindAsync(id);
            if (userWorkoutPlanUpdate == null)
                return NotFound();
            userWorkoutPlanUpdate.UserId = userWorkoutPlan.UserId;
            userWorkoutPlanUpdate.VideoId = userWorkoutPlan.VideoId;
            try
            {
                await _context.SaveChangesAsync();
                return NoContent(); // הצלחה בלי תוכן
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/<UserWorkoutPlanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
