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
        public interface IPersonRepository
        {
            Task<List<Person>> GetPeople();
            Task<Person> GetPersonById(int id);
            Task AddPerson(Person Person);
            Task UpdatePerson(Person Person);
            Task DeletePerson(int id);
        }

        public class PersonRepository : IPersonRepository
        {
            private readonly DbContext _dbContext;

            public PersonRepository(DbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public async Task<List<Person>> GetPeople()
            {
                return await _dbContext.Set<Person>().ToListAsync();
            }

            public async Task<Person> GetPersonById(int id)
            {
                return await _dbContext.Set<Person>().FindAsync(id);
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

            public async Task DeletePerson(int id)
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

}
