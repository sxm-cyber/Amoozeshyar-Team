using System;
namespace Amoozeshyar.Application.Commands
{
	public class UpdateProfileCommand
	{
        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}

