using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Repositories
    {
        public interface IPetRepository
        {
            Task<List<Pet>> GetPets();
            Task<Pet> GetPetById(int id);
            Task AddPet(Pet Pet);
            Task UpdatePet(Pet Pet);
            Task DeletePet(int id);
        }

        public class PetRepository : IPetRepository
        {
            private readonly DbContext _dbContext;

            public PetRepository(DbContext dbContext)
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

}
