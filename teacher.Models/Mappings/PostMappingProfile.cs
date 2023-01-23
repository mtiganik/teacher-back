using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Models.Dtos;
using teacher.Models.Models;

namespace teacher.Models.Mappings
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>().ReverseMap();
            CreateMap<TeachingTakesPlaceDto, TeachingTakesPlace>().ReverseMap();
            CreateMap<SubjectDto, Subject>().ReverseMap();
        }
    }
}
