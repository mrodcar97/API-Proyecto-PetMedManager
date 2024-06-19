using Domain;
using Repositories;


namespace Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonById(String id);
        Task<List<Person>> GetVetsByClinic(String clinicID);
        Task AddPerson(Person Person);
        Task UpdatePerson(Person Person);
        Task DeletePerson(string id);
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

        public async Task<Person> GetPersonById(string id)
        {
            return await _PersonRepository.GetPersonById(id);
        }

        public async Task<List<Person>> GetVetsByClinic(String clinicID)
        {
            return await _PersonRepository.GetVetsByClinic(clinicID);
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

        public async Task DeletePerson(string id)
        {
            await _PersonRepository.DeletePerson(id);
        }
    }
}
