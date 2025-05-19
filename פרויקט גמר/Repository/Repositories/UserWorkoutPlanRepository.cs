using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserWorkoutPlanRepository : IRepository<UserWorkoutPlan>
    {
        private readonly IContext context;
        public UserWorkoutPlanRepository(IContext context)
        {
            this.context = context;
        }
        public UserWorkoutPlan AddItem(UserWorkoutPlan item)
        {
            this.context.UserWorkoutPlans.Add(item);
            this.context.SaveChangesAsync();
            return item;
        }

        public void DeleteItem(int id)
        {
            this.context.UserWorkoutPlans.Remove(GetById(id));
            this.context.SaveChangesAsync();
        }

        public List<UserWorkoutPlan> GetAll()
        {
            return context.UserWorkoutPlans.ToList();
        }

        public UserWorkoutPlan GetById(int id)
        {
            return context.UserWorkoutPlans.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateItem(int id, UserWorkoutPlan item)
        {
            var userWorkoutPlan = GetById(id);
            userWorkoutPlan.UserId = item.UserId;
            userWorkoutPlan.User = item.User;
            userWorkoutPlan.VideoId = item.VideoId;
            userWorkoutPlan.WorkoutVideo = item.WorkoutVideo;
            context.SaveChangesAsync();
        }
    }
}
