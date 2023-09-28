using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;
using MySql.Data.MySqlClient;

namespace dotnet.Repository
{
    public class UserRegistrationRepository : IUserRegistrationService
    {
        private readonly string _connectionString;

        public UserRegistrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO UserRegistration (Username, FirstName, LastName, EmailAddress, MobileNumber, PhoneNumber, Role, Level, Notes, IsActive) " +
                            "VALUES (@Username, @FirstName, @LastName, @EmailAddress, @MobileNumber, @PhoneNumber, @Role, @Level, @Notes, @IsActive)";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Username", user.Username),
                    new MySqlParameter("@FirstName", user.FirstName),
                    new MySqlParameter("@LastName", user.LastName),
                    new MySqlParameter("@EmailAddress", user.EmailAddress),
                    new MySqlParameter("@MobileNumber", user.MobileNumber),
                    new MySqlParameter("@PhoneNumber", user.PhoneNumber),
                    new MySqlParameter("@Role", user.Role),
                    new MySqlParameter("@Level", user.Level),
                    new MySqlParameter("@Notes", user.Notes),
                    new MySqlParameter("@IsActive", user.IsActive)
                };

                var command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(parameters);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<UserRegistrationModel> GetUser(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserRegistration WHERE Id = @Id";
                var parameter = new MySqlParameter("@Id", id);

                var command = new MySqlCommand(query, connection);
                command.Parameters.Add(parameter);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new UserRegistrationModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            MobileNumber = reader["MobileNumber"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Role = reader["Role"].ToString(),
                            Level = reader["Level"].ToString(),
                            Notes = reader["Notes"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }
                }

                return null;
            }
        }

        public async Task<List<UserRegistrationModel>> GetUsers()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserRegistration";

                var command = new MySqlCommand(query, connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var users = new List<UserRegistrationModel>();

                    while (await reader.ReadAsync())
                    {
                        var user = new UserRegistrationModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            MobileNumber = reader["MobileNumber"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Role = reader["Role"].ToString(),
                            Level = reader["Level"].ToString(),
                            Notes = reader["Notes"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };

                        users.Add(user);
                    }

                    return users;
                }
            }
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE UserRegistration SET Username = @Username, FirstName = @FirstName, LastName = @LastName, " +
                            "EmailAddress = @EmailAddress, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, " +
                            "Role = @Role, Level = @Level, Notes = @Notes, IsActive = @IsActive WHERE Id = @Id";

                var parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Username", user.Username),
                    new MySqlParameter("@FirstName", user.FirstName),
                    new MySqlParameter("@LastName", user.LastName),
                    new MySqlParameter("@EmailAddress", user.EmailAddress),
                    new MySqlParameter("@MobileNumber", user.MobileNumber),
                    new MySqlParameter("@PhoneNumber", user.PhoneNumber),
                    new MySqlParameter("@Role", user.Role),
                    new MySqlParameter("@Level", user.Level),
                    new MySqlParameter("@Notes", user.Notes),
                    new MySqlParameter("@IsActive", user.IsActive),
                    new MySqlParameter("@Id", user.Id)
                };

                var command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(parameters);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM UserRegistration WHERE Id = @Id";
                var parameter = new MySqlParameter("@Id", id);

                var command = new MySqlCommand(query, connection);
                command.Parameters.Add(parameter);

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}