using DataContext;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public interface IShiftRepository
    {
        Task<List<Shift>> GetShifts();
        Task<Shift> GetShiftById(int id);
        Task<List<Shift>> GetShiftsByDate(DateOnly date);
        Task<List<Shift>> GetShiftsForMonth(int year, int month);
        Task AddShift(Shift Shift);
        Task UpdateShift(Shift Shift);
        Task DeleteShift(int id);
    }

    public class ShiftRepository : IShiftRepository
    {
        private readonly DataBaseContext _dbContext;

        public ShiftRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Shift>> GetShifts()
        {
            return await _dbContext.Set<Shift>().ToListAsync();
        }

        public async Task<List<Shift>> GetShiftsByDate(DateOnly date)
        {
            return await _dbContext.Set<Shift>()
                .Where(a => a.Date == date)
                .ToListAsync();
        }

        public async Task<List<Shift>> GetShiftsForMonth(int year, int month)
        {
            return await _dbContext.Shifts
            .Where(s => s.Date.Year == year && s.Date.Month == month)
            .ToListAsync();
        }

        public async Task<Shift> GetShiftById(int id)
        {
            return await _dbContext.Set<Shift>().FindAsync(id);
        }

        public async Task AddShift(Shift Shift)
        {
            await _dbContext.Set<Shift>().AddAsync(Shift);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateShift(Shift Shift)
        {
            _dbContext.Entry(Shift).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteShift(int id)
        {
            var Shift = await _dbContext.Set<Shift>().FindAsync(id);
            if (Shift != null)
            {
                _dbContext.Set<Shift>().Remove(Shift);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
