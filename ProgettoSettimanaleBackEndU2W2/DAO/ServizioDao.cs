using ProgettoSettimanaleBackEndU2W2.Interface;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.DAO
{
    public class ServizioDao : IServizioDao
    {
        private readonly string _connectionString;

        public ServizioDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<AdditionalService>> GetAllAsync()
        {
            var services = new List<AdditionalService>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM AdditionalServices", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var service = new AdditionalService
                        {
                            ServiceID = (int)reader["ServiceID"],
                            ReservationID = (int)reader["ReservationID"],
                            ServiceName = reader["ServiceName"].ToString(),
                            ServiceDate = (DateTime)reader["ServiceDate"],
                            Quantity = (int)reader["Quantity"],
                            Price = (decimal)reader["Price"]
                        };
                        services.Add(service);
                    }
                }
            }
            return services;
        }

        public async Task<AdditionalService> GetByIdAsync(int id)
        {
            AdditionalService service = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM AdditionalServices WHERE ServiceID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            service = new AdditionalService
                            {
                                ServiceID = (int)reader["ServiceID"],
                                ReservationID = (int)reader["ReservationID"],
                                ServiceName = reader["ServiceName"].ToString(),
                                ServiceDate = (DateTime)reader["ServiceDate"],
                                Quantity = (int)reader["Quantity"],
                                Price = (decimal)reader["Price"]
                            };
                        }
                    }
                }
            }
            return service;
        }

        public async Task AddAsync(AdditionalService servizio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("INSERT INTO AdditionalServices (ReservationID, ServiceName, ServiceDate, Quantity, Price) VALUES (@ReservationID, @ServiceName, @ServiceDate, @Quantity, @Price)", connection))
                {
                    command.Parameters.AddWithValue("@ReservationID", servizio.ReservationID);
                    command.Parameters.AddWithValue("@ServiceName", servizio.ServiceName);
                    command.Parameters.AddWithValue("@ServiceDate", servizio.ServiceDate);
                    command.Parameters.AddWithValue("@Quantity", servizio.Quantity);
                    command.Parameters.AddWithValue("@Price", servizio.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(AdditionalService servizio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("UPDATE AdditionalServices SET ReservationID = @ReservationID, ServiceName = @ServiceName, ServiceDate = @ServiceDate, Quantity = @Quantity, Price = @Price WHERE ServiceID = @ServiceID", connection))
                {
                    command.Parameters.AddWithValue("@ServiceID", servizio.ServiceID);
                    command.Parameters.AddWithValue("@ReservationID", servizio.ReservationID);
                    command.Parameters.AddWithValue("@ServiceName", servizio.ServiceName);
                    command.Parameters.AddWithValue("@ServiceDate", servizio.ServiceDate);
                    command.Parameters.AddWithValue("@Quantity", servizio.Quantity);
                    command.Parameters.AddWithValue("@Price", servizio.Price);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DELETE FROM AdditionalServices WHERE ServiceID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
