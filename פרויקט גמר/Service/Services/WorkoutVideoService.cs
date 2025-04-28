using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WorkoutVideoService: IService<WorkoutVideoDto>
    {
        private readonly IRepository<WorkoutVideo> repository;
        private readonly IMapper mapper;

        public WorkoutVideoService(IRepository<WorkoutVideo> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public WorkoutVideoDto AddItem(WorkoutVideoDto item)
        {
            return mapper.Map<WorkoutVideo, WorkoutVideoDto>(repository.AddItem(mapper.Map<WorkoutVideoDto, WorkoutVideo>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<WorkoutVideoDto> GetAll()
        {
            return mapper.Map<List<WorkoutVideo>, List<WorkoutVideoDto>>(repository.GetAll());
        }

        public WorkoutVideoDto GetById(int id)
        {
            return mapper.Map<WorkoutVideo, WorkoutVideoDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, WorkoutVideoDto item)
        {
            repository.UpdateItem(id, mapper.Map<WorkoutVideoDto, WorkoutVideo>(item));
        }
    }
}
