using _22Percent_BE.Data.DTOs.Report;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Sevices.ReportServices
{
    public interface IReportService
    {
        public Task<string?> Delete(string id);
        public Task<List<Report>> GetByUserName(string userName);
        public Task Create(CreateReportDto dto, string currentUser);
        public Task<List<Report>> GetByFilter(string userName, SearchReportDto dto);
    }
}
