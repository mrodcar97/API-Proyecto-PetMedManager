using Domain;
using Repositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(int id);
        Task AddPerson(Person Person);
        Task UpdatePerson(Person Person);
        Task DeletePerson(int id);
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonService(IPersonRepository PersonRepository)
        {
            _PersonRepository = PersonRepository ?? throw new ArgumentNullException(nameof(PersonRepository));
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _PersonRepository.GetPeople();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _PersonRepository.GetPersonById(id);
        }

        public async Task AddPerson(Person Person)
        {
            if (Person == null)
                throw new ArgumentNullException(nameof(Person));

            await _PersonRepository.AddPerson(Person);
        }

        public async Task UpdatePerson(Person Person)
        {
            if (Person == null)
                throw new ArgumentNullException(nameof(Person));

            await _PersonRepository.UpdatePerson(Person);
        }

        public async Task DeletePerson(int id)
        {
            await _PersonRepository.DeletePerson(id);
        }
    }
}
