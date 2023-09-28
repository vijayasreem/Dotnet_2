using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IDataAccess _dataAccess;

        public UserRegistrationService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            // Add logic to create a new user
            return await _dataAccess.CreateUser(user);
        }

        public async Task<UserRegistrationModel> GetUser(int id)
        {
            // Add logic to get a user by id
            return await _dataAccess.GetUser(id);
        }

        public async Task<List<UserRegistrationModel>> GetUsers()
        {
            // Add logic to get all users
            return await _dataAccess.GetUsers();
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            // Add logic to update a user
            return await _dataAccess.UpdateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            // Add logic to delete a user by id
            return await _dataAccess.DeleteUser(id);
        }
    }
}