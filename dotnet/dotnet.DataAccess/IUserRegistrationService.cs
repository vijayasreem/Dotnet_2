


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface IUserRegistrationService
    {
        Task<int> CreateUser(UserRegistrationModel user);
        Task<UserRegistrationModel> GetUser(int id);
        Task<List<UserRegistrationModel>> GetUsers();
        Task<int> UpdateUser(UserRegistrationModel user);
        Task<int> DeleteUser(int id);
    }
}
