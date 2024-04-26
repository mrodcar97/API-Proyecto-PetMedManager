using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClinicRepository
    {
        Task<List<Clinic>> GetClinics();
        Task<Clinic> GetClinicById(int id);
        Task AddClinic(Clinic Clinic);
        Task UpdateClinic(Clinic Clinic);
        Task DeleteClinic(int id);
    }

    public class ClinicRepository : IClinicRepository
    {
        private readonly DbContext _dbContext;

        public ClinicRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Clinic>> GetClinics()
        {
            return await _dbContext.Set<Clinic>().ToListAsync();
        }

        public async Task<Clinic> GetClinicById(int id)
        {
            return await _dbContext.Set<Clinic>().FindAsync(id);
        }

        public async Task AddClinic(Clinic Clinic)
        {
            await _dbContext.Set<Clinic>().AddAsync(Clinic);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClinic(Clinic Clinic)
        {
            _dbContext.Entry(Clinic).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteClinic(int id)
        {
            var Clinic = await _dbContext.Set<Clinic>().FindAsync(id);
            if (Clinic != null)
            {
                _dbContext.Set<Clinic>().Remove(Clinic);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
