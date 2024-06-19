using Domain;
using Microsoft.EntityFrameworkCore;
using DataContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositories
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPets();
        Task<Pet> GetPetById(int id);
        Task<List<Pet>> GetPetByOwnerId(string id);
        Task AddPet(Pet Pet);
        Task UpdatePet(Pet Pet);
        Task DeletePet(int id);
    }

    public class PetRepository : IPetRepository
    {
        private readonly DataBaseContext _dbContext;

        public PetRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _dbContext.Set<Pet>().ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _dbContext.Set<Pet>().FindAsync(id);
        }

        public async Task<List<Pet>> GetPetByOwnerId(string id)
        {
            return await _dbContext.Set<Pet>()
                .Where(p => p.OwnerId == id)
                .ToListAsync();
        }

        public async Task AddPet(Pet Pet)
        {
            await _dbContext.Set<Pet>().AddAsync(Pet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePet(Pet Pet)
        {
            _dbContext.Entry(Pet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePet(int id)
        {
            var Pet = await _dbContext.Set<Pet>().FindAsync(id);
            if (Pet != null)
            {
                _dbContext.Set<Pet>().Remove(Pet);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

