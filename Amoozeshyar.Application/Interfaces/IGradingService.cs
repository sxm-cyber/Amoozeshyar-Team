using Amoozeshyar.Application.DTOs;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IGradingService
	{
		Task SetGradeAsync(GradeCommand command);

	}
}

