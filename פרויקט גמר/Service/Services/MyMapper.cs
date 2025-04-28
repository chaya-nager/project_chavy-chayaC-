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
        public MyMapper()
        {
            //CreateMap<User,UserDto>().ForMember("",x=>);
        }
    }
}
