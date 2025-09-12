﻿using System;
namespace Amoozeshyar.Application.DTOs
{
	public class UserRegisterDto
	{
		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string Role { get; set; } = "Student";


	}
}

