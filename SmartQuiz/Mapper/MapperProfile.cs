using AutoMapper;
using SmartQuiz.Application.DTO;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
        }
    }
}
