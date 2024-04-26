using Domain;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPetService
    {
        Task<List<Pet>> GetPets();
        Task<Pet> GetPetById(int id);
        Task AddPet(Pet Pet);
        Task UpdatePet(Pet Pet);
        Task DeletePet(int id);
    }

    public class PetService : IPetService
    {
        private readonly IPetRepository _PetRepository;

        public PetService(IPetRepository PetRepository)
        {
            _PetRepository = PetRepository ?? throw new ArgumentNullException(nameof(PetRepository));
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _PetRepository.GetPets();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _PetRepository.GetPetById(id);
        }

        public async Task AddPet(Pet Pet)
        {
            if (Pet == null)
                throw new ArgumentNullException(nameof(Pet));

            await _PetRepository.AddPet(Pet);
        }

        public async Task UpdatePet(Pet Pet)
        {
            if (Pet == null)
                throw new ArgumentNullException(nameof(Pet));

            await _PetRepository.UpdatePet(Pet);
        }

        public async Task DeletePet(int id)
        {
            await _PetRepository.DeletePet(id);
        }
    }
}
