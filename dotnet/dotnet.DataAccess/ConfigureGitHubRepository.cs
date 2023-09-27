
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using dotnet.DTO;

namespace dotnet.Repository
{
    public class ConfigureGitHubRepository : IConfigureGitHubService
    {
        private readonly string connectionString;

        public ConfigureGitHubRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(ConfigureGitHubModel model)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var query = "INSERT INTO ConfigureGitHub (GitHubUsername, GitHubPassword, GitHubURL, RepositoryName) " +
                            "VALUES (@GitHubUsername, @GitHubPassword, @GitHubURL, @RepositoryName)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    cmd.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    cmd.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    cmd.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<ConfigureGitHubModel>> GetAllAsync()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var query = "SELECT Id, GitHubUsername, GitHubPassword, GitHubURL, RepositoryName FROM ConfigureGitHub";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var models = new List<ConfigureGitHubModel>();

                        while (await reader.ReadAsync())
                        {
                            var model = new ConfigureGitHubModel
                            {
                                Id = reader.GetInt32("Id"),
                                GitHubUsername = reader.GetString("GitHubUsername"),
                                GitHubPassword = reader.GetString("GitHubPassword"),
                                GitHubURL = reader.GetString("GitHubURL"),
                                RepositoryName = reader.GetString("RepositoryName")
                            };

                            models.Add(model);
                        }

                        return models;
                    }
                }
            }
        }

        public async Task<ConfigureGitHubModel> GetByIdAsync(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var query = "SELECT Id, GitHubUsername, GitHubPassword, GitHubURL, RepositoryName FROM ConfigureGitHub " +
                            "WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var model = new ConfigureGitHubModel
                            {
                                Id = reader.GetInt32("Id"),
                                GitHubUsername = reader.GetString("GitHubUsername"),
                                GitHubPassword = reader.GetString("GitHubPassword"),
                                GitHubURL = reader.GetString("GitHubURL"),
                                RepositoryName = reader.GetString("RepositoryName")
                            };

                            return model;
                        }

                        return null;
                    }
                }
            }
        }

        public async Task<int> UpdateAsync(ConfigureGitHubModel model)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var query = "UPDATE ConfigureGitHub SET GitHubUsername = @GitHubUsername, " +
                            "GitHubPassword = @GitHubPassword, GitHubURL = @GitHubURL, " +
                            "RepositoryName = @RepositoryName WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    cmd.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    cmd.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    cmd.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);
                    cmd.Parameters.AddWithValue("@Id", model.Id);

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var query = "DELETE FROM ConfigureGitHub WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
