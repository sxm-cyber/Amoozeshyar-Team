using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Amoozeshyar.Application.Commands
{
	public class UserRegisterCommand
	{
        [JsonPropertyName("FullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("Email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("Role")]
        public string Role { get; set; } = "Student";

        [JsonPropertyName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        public IFormFile File { get; set; }

    }
}

