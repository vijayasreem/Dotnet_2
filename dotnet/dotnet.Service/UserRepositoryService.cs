using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetNamespace.DataAccess;
using DotNetNamespace.DTO;

namespace DotNetNamespace.Service
{
    public class UserRepositoryService : IUserRepository
    {
        private readonly IUserRepositoryDataAccess _userRepositoryDataAccess;

        public UserRepositoryService(IUserRepositoryDataAccess userRepositoryDataAccess)
        {
            _userRepositoryDataAccess = userRepositoryDataAccess;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            // Add your business logic code here
            return await _userRepositoryDataAccess.CreateUser(user);
        }

        public async Task<UserRegistrationModel> GetUserById(int id)
        {
            // Add your business logic code here
            return await _userRepositoryDataAccess.GetUserById(id);
        }

        public async Task<List<UserRegistrationModel>> GetAllUsers()
        {
            // Add your business logic code here
            return await _userRepositoryDataAccess.GetAllUsers();
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            // Add your business logic code here
            return await _userRepositoryDataAccess.UpdateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            // Add your business logic code here
            return await _userRepositoryDataAccess.DeleteUser(id);
        }
    }
}