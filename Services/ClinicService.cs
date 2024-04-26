using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClinicService
    {
        Task<List<Clinic>> GetClinics();
        Task<Clinic> GetClinicById(int id);
        Task AddClinic(Clinic Clinic);
        Task UpdateClinic(Clinic Clinic);
        Task DeleteClinic(int id);
    }

    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _ClinicRepository;

        public ClinicService(IClinicRepository ClinicRepository)
        {
            _ClinicRepository = ClinicRepository ?? throw new ArgumentNullException(nameof(ClinicRepository));
        }

        public async Task<List<Clinic>> GetClinics()
        {
            return await _ClinicRepository.GetClinics();
        }

        public async Task<Clinic> GetClinicById(int id)
        {
            return await _ClinicRepository.GetClinicById(id);
        }

        public async Task AddClinic(Clinic Clinic)
        {
            if (Clinic == null)
                throw new ArgumentNullException(nameof(Clinic));

            await _ClinicRepository.AddClinic(Clinic);
        }

        public async Task UpdateClinic(Clinic Clinic)
        {
            if (Clinic == null)
                throw new ArgumentNullException(nameof(Clinic));

            await _ClinicRepository.UpdateClinic(Clinic);
        }

        public async Task DeleteClinic(int id)
        {
            await _ClinicRepository.DeleteClinic(id);
        }
    }
}
