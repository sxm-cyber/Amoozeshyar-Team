using System;
namespace Amoozeshyar.Application.DTOs
{
	public class FullProfileDto
	{
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePictureUrl { get; set; }
  
        public string UserName { get; set; }

        public string Role { get; set; }

       
        public List<CourseDto> Courses { get; set; } = new();
    }
}

