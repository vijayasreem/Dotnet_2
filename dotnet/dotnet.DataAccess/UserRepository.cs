using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DotNetNamespace
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> CreateUser(UserRegistrationModel user)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "INSERT INTO users (Username, FirstName, LastName, EmailAddress, MobileNumber, PhoneNumber, Role, Level, Notes, IsActive) " +
                           "VALUES (@Username, @FirstName, @LastName, @EmailAddress, @MobileNumber, @PhoneNumber, @Role, @Level, @Notes, @IsActive)";

            using MySqlCommand command = new MySqlCommand(query, connection);
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

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected;
        }

        public async Task<UserRegistrationModel> GetUserById(int id)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "SELECT * FROM users WHERE Id = @Id";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.Read())
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

            return null;
        }

        public async Task<List<UserRegistrationModel>> GetAllUsers()
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "SELECT * FROM users";

            using MySqlCommand command = new MySqlCommand(query, connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();

            List<UserRegistrationModel> users = new List<UserRegistrationModel>();

            while (reader.Read())
            {
                users.Add(new UserRegistrationModel
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
                });
            }

            return users;
        }

        public async Task<int> UpdateUser(UserRegistrationModel user)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "UPDATE users SET Username = @Username, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, " +
                           "MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, Role = @Role, Level = @Level, Notes = @Notes, IsActive = @IsActive " +
                           "WHERE Id = @Id";

            using MySqlCommand command = new MySqlCommand(query, connection);
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

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected;
        }

        public async Task<int> DeleteUser(int id)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "DELETE FROM users WHERE Id = @Id";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected;
        }
    }
}