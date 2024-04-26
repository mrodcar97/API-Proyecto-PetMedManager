using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IVisitHistoryRepository
    {
        Task<List<VisitHistory>> GetVisitHistories();
        Task<VisitHistory> GetVisitHistoryById(int id);
        Task AddVisitHistory(VisitHistory VisitHistory);
        Task UpdateVisitHistory(VisitHistory VisitHistory);
        Task DeleteVisitHistory(int id);
    }

    public class VisitHistoryRepository : IVisitHistoryRepository
    {
        private readonly DbContext _dbContext;

        public VisitHistoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<VisitHistory>> GetVisitHistories()
        {
            return await _dbContext.Set<VisitHistory>().ToListAsync();
        }

        public async Task<VisitHistory> GetVisitHistoryById(int id)
        {
            return await _dbContext.Set<VisitHistory>().FindAsync(id);
        }

        public async Task AddVisitHistory(VisitHistory VisitHistory)
        {
            await _dbContext.Set<VisitHistory>().AddAsync(VisitHistory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateVisitHistory(VisitHistory VisitHistory)
        {
            _dbContext.Entry(VisitHistory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVisitHistory(int id)
        {
            var VisitHistory = await _dbContext.Set<VisitHistory>().FindAsync(id);
            if (VisitHistory != null)
            {
                _dbContext.Set<VisitHistory>().Remove(VisitHistory);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
