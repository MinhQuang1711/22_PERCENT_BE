using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.ReportServices
{
    public class ReportService : IReportService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public ReportService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement = repositoryManagement;
        }
        public Task<List<Report>> GetByUserName(string userName)
        {
            return _repositoryManagement.ReportRepository.GetByUserName(userName);
        }
    }
}
