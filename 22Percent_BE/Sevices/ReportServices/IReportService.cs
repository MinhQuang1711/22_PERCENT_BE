using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Sevices.ReportServices
{
    public interface IReportService
    {
        public Task<List<Report>> GetByUserName(string userName);
    }
}
