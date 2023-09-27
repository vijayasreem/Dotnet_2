using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class ConfigureGitHubService : IConfigureGitHubService
    {
        private readonly IConfigureGitHubDataAccess _dataAccess;

        public ConfigureGitHubService(IConfigureGitHubDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreateAsync(ConfigureGitHubModel model)
        {
            return await _dataAccess.CreateAsync(model);
        }

        public async Task<List<ConfigureGitHubModel>> GetAllAsync()
        {
            return await _dataAccess.GetAllAsync();
        }

        public async Task<ConfigureGitHubModel> GetByIdAsync(int id)
        {
            return await _dataAccess.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(ConfigureGitHubModel model)
        {
            return await _dataAccess.UpdateAsync(model);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dataAccess.DeleteAsync(id);
        }
    }

    public interface IConfigureGitHubService : IConfigureGitHubDataAccess
    {
        Task<int> CreateAsync(ConfigureGitHubModel model);
        Task<List<ConfigureGitHubModel>> GetAllAsync();
        Task<ConfigureGitHubModel> GetByIdAsync(int id);
        Task<int> UpdateAsync(ConfigureGitHubModel model);
        Task<int> DeleteAsync(int id);
    }
}