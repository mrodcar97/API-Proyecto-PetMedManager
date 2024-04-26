using Domain;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITestService
    {
        Task<List<Test>> GetTests();
        Task<Test> GetTestById(int id);
        Task AddTest(Test Test);
        Task UpdateTest(Test Test);
        Task DeleteTest(int id);
    }

    public class TestService : ITestService
    {
        private readonly ITestRepository _TestRepository;

        public TestService(ITestRepository TestRepository)
        {
            _TestRepository = TestRepository ?? throw new ArgumentNullException(nameof(TestRepository));
        }

        public async Task<List<Test>> GetTests()
        {
            return await _TestRepository.GetTests();
        }

        public async Task<Test> GetTestById(int id)
        {
            return await _TestRepository.GetTestById(id);
        }

        public async Task AddTest(Test Test)
        {
            if (Test == null)
                throw new ArgumentNullException(nameof(Test));

            await _TestRepository.AddTest(Test);
        }

        public async Task UpdateTest(Test Test)
        {
            if (Test == null)
                throw new ArgumentNullException(nameof(Test));

            await _TestRepository.UpdateTest(Test);
        }

        public async Task DeleteTest(int id)
        {
            await _TestRepository.DeleteTest(id);
        }
    }
}
