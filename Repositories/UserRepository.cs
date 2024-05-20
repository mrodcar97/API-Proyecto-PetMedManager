using Microsoft.EntityFrameworkCore;
using Domain;
using DataContext;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dbContext;

        public UserRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Set<User>().FindAsync(id);
            if (user != null)
            {
                _dbContext.Set<User>().Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}