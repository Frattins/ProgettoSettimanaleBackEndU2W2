using ProgettoSettimanaleBackEndU2W2.Interface;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.DAO
{
    public class ClienteDao : IClienteDao
    {
        private readonly string _connectionString;

        public ClienteDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddClientAsync(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Clients (Code, Surname, Name, City, Province, Email, Phone, Mobile) VALUES (@Code, @Surname, @Name, @City, @Province, @Email, @Phone, @Mobile)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", client.Code);
                    command.Parameters.AddWithValue("@Surname", client.Surname);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@City", client.City);
                    command.Parameters.AddWithValue("@Province", client.Province);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Mobile", client.Mobile);

                    connection.Open();
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Clients SET Code = @Code, Surname = @Surname, Name = @Name, City = @City, Province = @Province, Email = @Email, Phone = @Phone, Mobile = @Mobile WHERE ClientID = @ClientID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", client.ClientID);
                    command.Parameters.AddWithValue("@Code", client.Code);
                    command.Parameters.AddWithValue("@Surname", client.Surname);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@City", client.City);
                    command.Parameters.AddWithValue("@Province", client.Province);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Mobile", client.Mobile);

                    connection.Open();
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Clients WHERE ClientID = @ClientID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", id);

                    connection.Open();
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Clients WHERE ClientID = @ClientID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", id);

                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Client
                            {
                                ClientID = reader.GetInt32(reader.GetOrdinal("ClientID")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Surname = reader.GetString(reader.GetOrdinal("Surname")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Province = reader.GetString(reader.GetOrdinal("Province")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Mobile = reader.GetString(reader.GetOrdinal("Mobile"))
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Clients WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Client
                            {
                                ClientID = reader.GetInt32(reader.GetOrdinal("ClientID")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Surname = reader.GetString(reader.GetOrdinal("Surname")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Province = reader.GetString(reader.GetOrdinal("Province")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Mobile = reader.GetString(reader.GetOrdinal("Mobile"))
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            var clients = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Clients";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clients.Add(new Client
                            {
                                ClientID = reader.GetInt32(reader.GetOrdinal("ClientID")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Surname = reader.GetString(reader.GetOrdinal("Surname")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                City = reader.GetString(reader.GetOrdinal("City")),
                                Province = reader.GetString(reader.GetOrdinal("Province")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Mobile = reader.GetString(reader.GetOrdinal("Mobile"))
                            });
                        }
                    }
                }
            }

            return clients;
        }
    }
}
