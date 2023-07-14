using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace DomainServices.Mapping
{
    public class MapProfile : Profile
    {
       public MapProfile() 
       { 
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<School, SchoolDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
       }
    }
}
