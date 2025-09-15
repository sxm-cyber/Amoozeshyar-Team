using Amoozeshyar.Application.Interfaces;
using Amoozeshyar.Domain;

namespace Amoozeshyar.Application.Service
{
    public class ReportService : IReportService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public ReportService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // ... + life time
    }
}
