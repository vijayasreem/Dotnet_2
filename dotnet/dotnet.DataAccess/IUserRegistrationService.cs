


using dotnet.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet.Service
{
    public interface IUserRegistrationService
    {
        Task<int> CreateUser(UserRegistrationModel user);
        Task<UserRegistrationModel> GetUserById(int id);
        Task<List<UserRegistrationModel>> GetAllUsers();
        Task<int> UpdateUser(UserRegistrationModel user);
        Task<int> DeleteUser(int id);
    }
}
