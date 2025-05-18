using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutVideoController : ControllerBase
    {
        private readonly IService<WorkoutVideoDto> service;
        private readonly IContext _context;

        public WorkoutVideoController(IService<WorkoutVideoDto> service, IContext _context)
        {
            this.service = service;
            this._context = _context;
        }
        // GET: api/<WorkoutVideoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutVideo>>> GetWorkoutVideo()
        {
            return await _context.WorkoutVideos.ToListAsync();
        }


        // GET api/<WorkoutVideoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutVideo>> GetWorkoutVideoById(int id)
        {
            var WorkoutVideo = await _context.WorkoutVideos.FindAsync(id);
            if (WorkoutVideo == null)
            {
                return NotFound();
            }
            return WorkoutVideo;
        }

        // POST api/<WorkoutVideoController>
        [HttpPost]
        public void Post([FromForm] WorkoutVideoDto workoutVideo)
        {
            UploadVideo(workoutVideo.fileVideo);
            service.AddItem(workoutVideo);
        }

        // PUT api/<WorkoutVideoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkoutVideo workoutVideo)
        {
            if (id != workoutVideo.VideoId)
            {
                return BadRequest("User ID mismatch.");
            }
            var workoutVideoUpdate = await _context.WorkoutVideos.FindAsync(id);
            if (workoutVideoUpdate == null)
            {
                return NotFound();
            }
            workoutVideoUpdate.Title = workoutVideo.Title;
            workoutVideoUpdate.Description = workoutVideo.Description;
            workoutVideoUpdate.Duration = workoutVideo.Duration;
            workoutVideoUpdate.DifficultyLevel = workoutVideo.DifficultyLevel;
            workoutVideoUpdate.WorkoutType = workoutVideo.WorkoutType;
            workoutVideoUpdate.TargetAudience = workoutVideo.TargetAudience;
            workoutVideoUpdate.VideoUrl = workoutVideo.VideoUrl;
            workoutVideoUpdate.UploadedAt = workoutVideo.UploadedAt;
            workoutVideoUpdate.TrainerId = workoutVideo.TrainerId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // DELETE api/<WorkoutVideoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutVideo(int id)
        {
            var workoutVideo = await _context.WorkoutVideos.FindAsync(id);
            if (workoutVideo == null)
            {
                return NotFound();
            }
            _context.WorkoutVideos.Remove(workoutVideo);
            await _context.SaveChangesAsync();
            return NoContent(); // מחזיר 204 בלי תוכן
        }

        private void UploadVideo(IFormFile file)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Videos/", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
