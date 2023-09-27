
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface IConfigureGitHubService
    {
        Task<int> CreateAsync(ConfigureGitHubModel model);
        Task<List<ConfigureGitHubModel>> GetAllAsync();
        Task<ConfigureGitHubModel> GetByIdAsync(int id);
        Task<int> UpdateAsync(ConfigureGitHubModel model);
        Task<int> DeleteAsync(int id);
    }
}
