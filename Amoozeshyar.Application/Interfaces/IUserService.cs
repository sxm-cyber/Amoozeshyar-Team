using Amoozeshyar.Application.Commands;

namespace Amoozeshyar.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(UserRegisterCommand command);
        Task<string> LoginAsync(UserLoginCommand command);
        Task<string> ForgotPasswordAsync(ForgotPasswordCommand dto);
        Task ResetPasswordAsync(string email, string token, string newPassword);
    }
}
