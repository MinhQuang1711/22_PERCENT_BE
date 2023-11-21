using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ReportRepo
{
    public interface IReportRepository
    {
        public Task Create(Report report);
        public Task<string?> Delete(string id);
        public Task<List<Report>> GetByUserName(string userName);
        public Task<List<Report>> GetByFilter(string uerName, DateTime? fromTime, DateTime? toTime);

    }
}
