using System;
using Amoozeshyar.Application.Commands;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IProfileService
	{
        Task<FullProfileDto> CreateProfileAsync(UserRegisterCommand command);

        Task<FullProfileDto> GetFullProfileAsync(Guid userId);

    }
}

