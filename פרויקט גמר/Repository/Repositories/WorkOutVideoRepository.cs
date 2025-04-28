using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class WorkoutVideoRepository : IRepository<WorkoutVideo>
    {
        private readonly IContext context;
        public WorkoutVideoRepository(IContext context)
        {
            this.context = context;
        }
        public WorkoutVideo AddItem(WorkoutVideo item)
        {
            this.context.WorkoutVideos.Add(item);
            this.context.Save();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.WorkoutVideos.Remove(GetById(id));
            this.context.Save();
        }

        public List<WorkoutVideo> GetAll()
        {
            return context.WorkoutVideos.ToList();
        }

        public WorkoutVideo GetById(int id)
        {
            return context.WorkoutVideos.FirstOrDefault(x => x.VideoId == id);
        }

        public void UpdateItem(int id, WorkoutVideo item)
        {
            var workoutVideo = GetById(id);
            workoutVideo.Title = item.Title;
            workoutVideo.Description = item.Description;
            workoutVideo.Duration = item.Duration;
            workoutVideo.DifficultyLevel = item.DifficultyLevel;
            workoutVideo.WorkoutType = item.WorkoutType;
            workoutVideo.TargetAudience = item.TargetAudience;
            workoutVideo.VideoUrl = item.VideoUrl;
            workoutVideo.UploadedAt = item.UploadedAt;
            workoutVideo.TrainerId = item.TrainerId;
            workoutVideo.Trainer = item.Trainer;
            context.Save();
        }
    }
}
