using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MyMapper:Profile
    {
        string path=Path.Combine(Environment.CurrentDirectory, "Videos//");

        public MyMapper()
        {
            CreateMap<WorkoutVideo, WorkoutVideoDto>().ForMember("VideoArr", x => x.MapFrom(y => File.ReadAllBytes(path + y.VideoUrl)));
            CreateMap<WorkoutVideoDto,WorkoutVideo>().ForMember("VideoUrl", x=>x.MapFrom(y=>y.fileVideo.FileName));
            CreateMap<UserWorkoutPlan, UserWorkoutPlanDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
