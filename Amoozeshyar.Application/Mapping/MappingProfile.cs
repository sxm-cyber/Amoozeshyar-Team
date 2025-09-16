using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.DTOs;
using Amoozeshyar.Domain.Models;
using AutoMapper;

namespace Amoozeshyar.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserRegisterCommand, ApplicationUser>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(scr => scr.Email));

			CreateMap<CourseCommand, Course>().ReverseMap();
			CreateMap<EnrollmentCommand, Enrollment>().ReverseMap();
			CreateMap<GradeCommand, Enrollment>()
				.ForMember(dest => dest.Grade, opt => opt.MapFrom(scr => scr.Grade));


			CreateMap<Enrollment, StudentCourseReportDto>()
				.ForMember(dest => dest.StudentId, opt => opt.MapFrom(scr => scr.StudentId))
				.ForMember(dest => dest.StudentName, opt => opt.MapFrom(scr => scr.Student != null ? $"{scr.Student.FirstName} {scr.Student.LastName}" : ""))
				.ForMember(dest => dest.CourseName, opt => opt.MapFrom(scr => scr.Course != null ? scr.Course.Name : ""))
				//.ForMember(dest => dest.Semester, opt => opt.MapFrom(scr => scr.Course != null ? scr.Course.Semester : ""))
				.ForMember(dest => dest.Grade, opt => opt.MapFrom(scr => scr.Grade));


			CreateMap<Enrollment, StudentTranscriptDto>()
				.ForMember(dest => dest.CourseName, opt => opt.MapFrom(scr => scr.Course != null ? scr.Course.Name : ""))
				.ForMember(dest => dest.Semester, opt => opt.MapFrom(scr => scr.Course != null ? scr.Course.Name : ""))
				.ForMember(dest => dest.Grade, opt => opt.MapFrom(scr => scr.Grade));
        }
		
	}
}

