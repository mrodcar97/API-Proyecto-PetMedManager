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
        public interface ITestRepository
        {
            Task<List<Test>> GetTests();
            Task<Test> GetTestById(int id);
            Task AddTest(Test Test);
            Task UpdateTest(Test Test);
            Task DeleteTest(int id);
        }

        public class TestRepository : ITestRepository
        {
            private readonly DbContext _dbContext;

            public TestRepository(DbContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            }

            public async Task<List<Test>> GetTests()
            {
                return await _dbContext.Set<Test>().ToListAsync();
            }

            public async Task<Test> GetTestById(int id)
            {
                return await _dbContext.Set<Test>().FindAsync(id);
            }

            public async Task AddTest(Test Test)
            {
                await _dbContext.Set<Test>().AddAsync(Test);
                await _dbContext.SaveChangesAsync();
            }

            public async Task UpdateTest(Test Test)
            {
                _dbContext.Entry(Test).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteTest(int id)
            {
                var Test = await _dbContext.Set<Test>().FindAsync(id);
                if (Test != null)
                {
                    _dbContext.Set<Test>().Remove(Test);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }

}
