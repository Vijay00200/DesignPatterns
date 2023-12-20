using System;
using AutoMapper;
using Specification.Data.Dto;
using Specification.Data.Models;

namespace Specification
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieDto>().ReverseMap();
        }
    }
}
