using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int id);
    }

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DbContext _dbContext;

        public AppointmentRepository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _dbContext.Set<Appointment>().ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _dbContext.Set<Appointment>().FindAsync(id);
        }

        public async Task AddAppointment(Appointment Appointment)
        {
            await _dbContext.Set<Appointment>().AddAsync(Appointment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAppointment(Appointment Appointment)
        {
            _dbContext.Entry(Appointment).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var Appointment = await _dbContext.Set<Appointment>().FindAsync(id);
            if (Appointment != null)
            {
                _dbContext.Set<Appointment>().Remove(Appointment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
    }
