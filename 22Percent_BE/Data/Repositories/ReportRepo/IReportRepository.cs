using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ReportRepo
{
    public interface IReportRepository
    {
        public Task<List<Report>> GetByUserName(string userName);
    }
}
