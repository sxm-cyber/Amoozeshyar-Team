using System.Text.Json.Serialization;
namespace Amoozeshyar.Application.Commands
{
	public class UserRegisterCommand
	{
		[JsonPropertyName("username")]
		public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = string.Empty;
        
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public string Role { get; set; } = "Student";


	}
}

