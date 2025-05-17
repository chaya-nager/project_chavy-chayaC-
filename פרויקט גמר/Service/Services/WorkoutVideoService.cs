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
    public class WorkoutVideoService: IService<Common.Dto.WorkoutVideoDto>
    {
        private readonly IRepository<Repository.Entities.WorkoutVideo> repository;
        private readonly IMapper mapper;

        public WorkoutVideoService(IRepository<Repository.Entities.WorkoutVideo> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Common.Dto.WorkoutVideoDto AddItem(Common.Dto.WorkoutVideoDto item)
        {
            return mapper.Map<WorkoutVideo, WorkoutVideoDto>(repository.AddItem(mapper.Map<WorkoutVideoDto, WorkoutVideo>(item)));
        }

        public void DeleteItem(int id)
        {
            repository.DeleteItem(id);
        }

        public List<Common.Dto.WorkoutVideoDto> GetAll()
        {
            return mapper.Map<List<WorkoutVideo>, List<WorkoutVideoDto>>(repository.GetAll());
        }

        public Common.Dto.WorkoutVideoDto GetById(int id)
        {
            return mapper.Map<WorkoutVideo, WorkoutVideoDto>(repository.GetById(id));
        }

        public void UpdateItem(int id, Common.Dto.WorkoutVideoDto item)
        {
            repository.UpdateItem(id, mapper.Map<WorkoutVideoDto, WorkoutVideo>(item));
        }
    }
}
