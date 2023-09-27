using dotnet.DataAccess;
using dotnet.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationDataAccess _userRegistrationDataAccess;

        public UserRegistrationService(IUserRegistrationDataAccess userRegistrationDataAccess)
        {
            _userRegistrationDataAccess = userRegistrationDataAccess;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            // Add logic to create a new user
            return await _userRegistrationDataAccess.CreateUser(user);
        }

        public async Task<UserRegistrationModel> GetUserById(int id)
        {
            // Add logic to get a user by ID
            return await _userRegistrationDataAccess.GetUserById(id);
        }

        public async Task<List<UserRegistrationModel>> GetAllUsers()
        {
            // Add logic to get all users
            return await _userRegistrationDataAccess.GetAllUsers();
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            // Add logic to update a user
            return await _userRegistrationDataAccess.UpdateUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            // Add logic to delete a user
            return await _userRegistrationDataAccess.DeleteUser(id);
        }
    }
}