using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(int id);
        Task<List<Appointment>> GetAppointmentsByDate(DateOnly date);
        Task AddAppointment(Appointment Appointment);
        Task UpdateAppointment(Appointment Appointment);
        Task DeleteAppointment(int id);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;

        public AppointmentService(IAppointmentRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository ?? throw new ArgumentNullException(nameof(AppointmentRepository));
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _AppointmentRepository.GetAppointments();
        }

        public async Task<List<Appointment>> GetAppointmentsByDate(DateOnly date)
        {
            return await _AppointmentRepository.GetAppointmentsByDate(date);
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _AppointmentRepository.GetAppointmentById(id);
        }

        public async Task AddAppointment(Appointment Appointment)
        {
            if (Appointment == null)
                throw new ArgumentNullException(nameof(Appointment));

            await _AppointmentRepository.AddAppointment(Appointment);
        }

        public async Task UpdateAppointment(Appointment Appointment)
        {
            if (Appointment == null)
                throw new ArgumentNullException(nameof(Appointment));

            await _AppointmentRepository.UpdateAppointment(Appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            await _AppointmentRepository.DeleteAppointment(id);
        }
    }
}
