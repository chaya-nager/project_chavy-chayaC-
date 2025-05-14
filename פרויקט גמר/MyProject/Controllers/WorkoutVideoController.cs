using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutVideoController : ControllerBase
    {
        private readonly IService<WorkoutVideoDto> service;
        public WorkoutVideoController(IService<WorkoutVideoDto> service)
        {
            this.service = service;
        }
        // GET: api/<WorkoutVideoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorkoutVideoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkoutVideoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
