


using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetNamespace.DTO;

namespace DotNetNamespace.Service
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserRegistrationModel user);
        Task<UserRegistrationModel> GetUserById(int id);
        Task<List<UserRegistrationModel>> GetAllUsers();
        Task<int> UpdateUser(UserRegistrationModel user);
        Task<int> DeleteUser(int id);
    }
}
