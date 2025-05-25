﻿using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutVideoController : ControllerBase
    {
        private readonly IService<WorkoutVideoDto> _service;
      

        public WorkoutVideoController(IService<WorkoutVideoDto> service)
        {
            this._service = service;
            
        }
        // GET: api/<WorkoutVideoController>
        [HttpGet]
        public async Task<ActionResult<List<WorkoutVideoDto>>> GetWorkoutVideo()
        {
            return  Ok(await _service.GetAllAsync());
        }


        // GET api/<WorkoutVideoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutVideoDto>> GetWorkoutVideoById(int id)
        {
            var WorkoutVideo =await _service.GetByIdAsync(id);
            if (WorkoutVideo == null)
            {
                return NotFound();
            }
            return Ok(WorkoutVideo);
        }

        // POST api/<WorkoutVideoController>
        [HttpPost]
        public async Task Post([FromForm] WorkoutVideoDto workoutVideo)
        {
            UploadVideo(workoutVideo.fileVideo);
            await _service.AddItemAsync(workoutVideo);
        }

        // PUT api/<WorkoutVideoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] WorkoutVideoDto workoutVideo)
        {
            if (id != workoutVideo.VideoId)
            {
                return BadRequest("User ID mismatch.");
            }
            var workoutVideoUpdate = await _service.GetByIdAsync(id);
            if (workoutVideoUpdate == null)
            {
                return NotFound();
            }
            await _service.UpdateItemAsync(id, workoutVideo);
            return NoContent();
        }
        // DELETE api/<WorkoutVideoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutVideo(int id)
        {            
           await _service.DeleteItemAsync(id);
            return Ok();
        }

        private async Task UploadVideo(IFormFile file)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Videos\\", file.FileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
