using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProjectApi.Dto;
using FinalProjectApi.Entity;

namespace FinalProjectApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();
           // CreateMap<IEnumerable<VisitDto>, IEnumerable<Visit>>();
            //CreateMap<IEnumerable<Visit>, IEnumerable<VisitDto>>();
            
        }
    }

}
