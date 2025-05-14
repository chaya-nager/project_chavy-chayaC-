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
        public UserWorkoutPlanDto AddItem(UserWorkoutPlanDto item)
        {
            return mapper.Map<UserWorkoutPlan, UserWorkoutPlanDto>(repository.AddItem(mapper.Map<UserWorkoutPlanDto, UserWorkoutPlan>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<UserWorkoutPlanDto> GetAll()
        { 
            return mapper.Map<List<UserWorkoutPlan>, List<UserWorkoutPlanDto>>(repository.GetAll());
        }
        public UserWorkoutPlanDto GetById(int id)
        {
            return mapper.Map<UserWorkoutPlan, UserWorkoutPlanDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, UserWorkoutPlanDto item)
        {
            repository.UpdateItem(id, mapper.Map<UserWorkoutPlanDto, UserWorkoutPlan>(item));
        }
    }
}
