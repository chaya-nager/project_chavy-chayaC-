using Microsoft.EntityFrameworkCore;
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
        public async Task<UserWorkoutPlan> AddItemAsync(UserWorkoutPlan item)
        {
            await context.UserWorkoutPlans.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                context.UserWorkoutPlans.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<UserWorkoutPlan>> GetAllAsync()
        {
            return await context.UserWorkoutPlans.ToListAsync();
        }

        public async Task<UserWorkoutPlan> GetByIdAsync(int id)
        {
            return await context.UserWorkoutPlans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateItemAsync(int id, UserWorkoutPlan item)
        {
            var userWorkoutPlan =await GetByIdAsync(id);
            if (userWorkoutPlan != null)
            {
                userWorkoutPlan.UserId = item.UserId;
                userWorkoutPlan.User = item.User;
                userWorkoutPlan.WorkoutPlanVideos = item.WorkoutPlanVideos;
                await context.SaveChangesAsync();
            }
        }
    }
}
