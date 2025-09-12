using System;
using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IGradingService
	{
		Task SetGradeAsync(GradeDto dto);



	}
}

