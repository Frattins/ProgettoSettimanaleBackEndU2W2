using ProgettoSettimanaleBackEndU2W2.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.DAO
{
    public class PrenotazioneDao : IPrenotazioneDao
    {
        private readonly string _connectionString;

        public PrenotazioneDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddAsync(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Reservations (ClientID, RoomID, ReservationDate, ProgressiveNumber, Year, StayFrom, StayTo, Deposit, RateApplied, Details) " +
                            "VALUES (@ClientID, @RoomID, @ReservationDate, @ProgressiveNumber, @Year, @StayFrom, @StayTo, @Deposit, @RateApplied, @Details)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientID", reservation.ClientID);
                command.Parameters.AddWithValue("@RoomID", reservation.RoomID);
                command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                command.Parameters.AddWithValue("@ProgressiveNumber", reservation.ProgressiveNumber);
                command.Parameters.AddWithValue("@Year", reservation.Year);
                command.Parameters.AddWithValue("@StayFrom", reservation.StayFrom);
                command.Parameters.AddWithValue("@StayTo", reservation.StayTo);
                command.Parameters.AddWithValue("@Deposit", reservation.Deposit);
                command.Parameters.AddWithValue("@RateApplied", reservation.RateApplied);
                command.Parameters.AddWithValue("@Details", reservation.Details);

                await connection.OpenAsync();
                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Reservations SET ClientID = @ClientID, RoomID = @RoomID, ReservationDate = @ReservationDate, " +
                            "ProgressiveNumber = @ProgressiveNumber, Year = @Year, StayFrom = @StayFrom, StayTo = @StayTo, " +
                            "Deposit = @Deposit, RateApplied = @RateApplied, Details = @Details WHERE ReservationID = @ReservationID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
                command.Parameters.AddWithValue("@ClientID", reservation.ClientID);
                command.Parameters.AddWithValue("@RoomID", reservation.RoomID);
                command.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                command.Parameters.AddWithValue("@ProgressiveNumber", reservation.ProgressiveNumber);
                command.Parameters.AddWithValue("@Year", reservation.Year);
                command.Parameters.AddWithValue("@StayFrom", reservation.StayFrom);
                command.Parameters.AddWithValue("@StayTo", reservation.StayTo);
                command.Parameters.AddWithValue("@Deposit", reservation.Deposit);
                command.Parameters.AddWithValue("@RateApplied", reservation.RateApplied);
                command.Parameters.AddWithValue("@Details", reservation.Details);

                await connection.OpenAsync();
                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", id);

                await connection.OpenAsync();
                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", id);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Reservation
                        {
                            ReservationID = reader.GetInt32(0),
                            ClientID = reader.GetInt32(1),
                            RoomID = reader.GetInt32(2),
                            ReservationDate = reader.GetDateTime(3),
                            ProgressiveNumber = reader.GetInt32(4),
                            Year = reader.GetInt32(5),
                            StayFrom = reader.GetDateTime(6),
                            StayTo = reader.GetDateTime(7),
                            Deposit = reader.GetDecimal(8),
                            RateApplied = reader.GetDecimal(9),
                            Details = reader.GetString(10)
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            var reservations = new List<Reservation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Reservations";
                var command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        reservations.Add(new Reservation
                        {
                            ReservationID = reader.GetInt32(0),
                            ClientID = reader.GetInt32(1),
                            RoomID = reader.GetInt32(2),
                            ReservationDate = reader.GetDateTime(3),
                            ProgressiveNumber = reader.GetInt32(4),
                            Year = reader.GetInt32(5),
                            StayFrom = reader.GetDateTime(6),
                            StayTo = reader.GetDateTime(7),
                            Deposit = reader.GetDecimal(8),
                            RateApplied = reader.GetDecimal(9),
                            Details = reader.GetString(10)
                        });
                    }
                }
            }
            return reservations;
        }
    }
}
