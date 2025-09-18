using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
    public interface IUserService
    {
        Task<FullProfileDto> RegisterAsync(UserRegisterCommand command);
        Task<string> LoginAsync(UserLoginCommand command);
        Task<string> ForgotPasswordAsync(ForgotPasswordCommand dto);
        Task ResetPasswordAsync(string email, string token, string newPassword);
    }
}
