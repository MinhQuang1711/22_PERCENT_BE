using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.ReportRepo
{
    public class ReportRepository : IReportRepository
    {
        private readonly _22Context _context;

        public ReportRepository(_22Context context) 
        {
            _context = context;
        }
        public async Task<List<Report>> GetByUserName(string userName)
        {
            return await _context.Reports.Where(e => e.CreateUser == userName).ToListAsync();
        }
    }
}
