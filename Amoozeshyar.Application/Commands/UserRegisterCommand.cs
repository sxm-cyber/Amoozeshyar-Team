using System.Text.Json.Serialization;
namespace Amoozeshyar.Application.Commands
{
	public class UserRegisterCommand
	{
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public string Role { get; set; } = "Student";

        public string? PhoneNumber { get; set; }

        public Stream? FileStream { get; set; }

        public string? FileName { get; set; }


    }
}

