using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
namespace Service.Services
{
    public class UserWorkoutPlanService : IService<UserWorkoutPlanDto>
    {
        private readonly IRepository<UserWorkoutPlan> repository;
        private readonly IMapper mapper;

        public UserWorkoutPlanService(IRepository<UserWorkoutPlan> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserWorkoutPlanDto> AddItemAsync(UserWorkoutPlanDto item)
        {
            return mapper.Map<UserWorkoutPlan, UserWorkoutPlanDto>(await  repository.AddItemAsync(mapper.Map<UserWorkoutPlanDto,UserWorkoutPlan>(item)));
        }

        public async Task DeleteItemAsync(int id)
        {
            await repository.DeleteItemAsync(id);
        }

        public async Task<List<UserWorkoutPlanDto>> GetAllAsync()
        { 
            return mapper.Map<List<UserWorkoutPlan>, List<UserWorkoutPlanDto>>(await repository.GetAllAsync());
        }
        public async Task<UserWorkoutPlanDto> GetByIdAsync(int id)
        {
            return mapper.Map<UserWorkoutPlan, UserWorkoutPlanDto>(await repository.GetByIdAsync(id));
        }

        public async Task UpdateItemAsync(int id, UserWorkoutPlanDto item)
        {
             await repository.UpdateItemAsync(id, mapper.Map<UserWorkoutPlanDto, UserWorkoutPlan>(item));
        }
    }
}
