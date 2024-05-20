using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository ?? throw new ArgumentNullException(nameof(UserRepository));
        }

        public async Task<List<User>> GetUsers()
        {
            return await _UserRepository.GetUsers();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _UserRepository.GetUserByEmail(email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _UserRepository.GetUserById(id);
        }

        public async Task AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _UserRepository.AddUser(user);
        }

        public async Task UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _UserRepository.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _UserRepository.DeleteUser(id);
        }      
    }
}

