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

        public async Task Create(Report report)
        {
           _context.Reports.Add(report);
            await _context.SaveChangesAsync();  
        }

        public async Task<string?> Delete(string id)
        {
            var report = await _context.Reports.SingleOrDefaultAsync(e=> e.Id==id);
            if (report != null)
            {
                _context.Remove(report);
                await _context.SaveChangesAsync();
                return null;
            }
            return Message.ReportNotExist; 
        }

        public async Task<List<Report>> GetByFilter(string uerName, DateTime? fromTime, DateTime? toTime)
        {
            var filter = _context.Reports.AsQueryable().Where(e=> e.CreateUser==uerName);
            if (fromTime != null)
            {
                filter = filter.Where(e => e.CreateDate >= fromTime); 
            }
            if (toTime != null)
            {
                filter = filter.Where(e => e.CreateDate <= toTime); 
            }
            return  await filter.ToListAsync();
        }

        public async Task<List<Report>> GetByUserName(string userName)
        {
            return await _context.Reports.Where(e => e.CreateUser == userName).ToListAsync();
        }
    }
}
