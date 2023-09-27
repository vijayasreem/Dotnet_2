using dotnet.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet.Repository
{
    public class UserRegistrationRepository : IUserRegistrationService
    {
        private readonly string connectionString;

        public UserRegistrationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO UserRegistration (Username, FirstName, LastName, EmailAddress, MobileNumber, PhoneNumber, Role, Level, Notes, IsActive) " +
                            "VALUES (@Username, @FirstName, @LastName, @EmailAddress, @MobileNumber, @PhoneNumber, @Role, @Level, @Notes, @IsActive)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@Level", user.Level);
                    command.Parameters.AddWithValue("@Notes", user.Notes);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<UserRegistrationModel> GetUserById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserRegistration WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapUserFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<List<UserRegistrationModel>> GetAllUsers()
        {
            var users = new List<UserRegistrationModel>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM UserRegistration";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var user = MapUserFromReader(reader);
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE UserRegistration SET Username = @Username, FirstName = @FirstName, LastName = @LastName, " +
                            "EmailAddress = @EmailAddress, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, Role = @Role, " +
                            "Level = @Level, Notes = @Notes, IsActive = @IsActive WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                    command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@Level", user.Level);
                    command.Parameters.AddWithValue("@Notes", user.Notes);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    command.Parameters.AddWithValue("@Id", user.Id);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM UserRegistration WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        private UserRegistrationModel MapUserFromReader(IDataReader reader)
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
}