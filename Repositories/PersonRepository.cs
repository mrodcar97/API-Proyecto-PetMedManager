using Domain;
using DataContext;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(String id);
        Task<List<Person>> GetVetsByClinic(String clinicID);
        Task AddPerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(string id);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly DataBaseContext _dbContext;

        public PersonRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _dbContext.Set<Person>().ToListAsync();
        }

        public async Task<Person> GetPersonById(string id)
        {
            return await _dbContext.Set<Person>().FindAsync(id);
        }

        public async Task<List<Person>> GetVetsByClinic(String clinicID)
        {
            return await _dbContext.Set<Person>()
                .Where(p => p.ClinicId == Convert.ToInt32(clinicID) && p.Rol == "Veterinario") 
                .ToListAsync();
        }

        public async Task AddPerson(Person Person)
        {
            await _dbContext.Set<Person>().AddAsync(Person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePerson(Person Person)
        {
            _dbContext.Entry(Person).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(string id)
        {
            var Person = await _dbContext.Set<Person>().FindAsync(id);
            if (Person != null)
            {
                _dbContext.Set<Person>().Remove(Person);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
