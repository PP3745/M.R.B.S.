using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace M.R.B.S_
{
    public static class DatabaseHelper
    {
        private const string DbFileName = "Bookings.db";
        private static readonly string ConnectionString = $"Data Source={DbFileName};";

        public static void InitializeDatabase()
        {
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Bookings (
                        BookingID TEXT PRIMARY KEY,
                        RoomName TEXT NOT NULL,
                        BookerName TEXT NOT NULL,
                        Date TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Purpose TEXT
                    );";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public static void InsertBooking(Booking b)
        {
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Bookings (BookingID, RoomName, BookerName, Date, StartTime, EndTime, Purpose)
                    VALUES (@id, @room, @booker, @date, @start, @end, @purpose);";
                cmd.Parameters.AddWithValue("@id", b.BookingID);
                cmd.Parameters.AddWithValue("@room", b.RoomName);
                cmd.Parameters.AddWithValue("@booker", b.BookerName);
                cmd.Parameters.AddWithValue("@date", b.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@start", b.StartTime.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@end", b.EndTime.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@purpose", b.Purpose ?? string.Empty);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public static void UpdateBooking(Booking b)
        {
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Bookings
                    SET RoomName = @room,
                        BookerName = @booker,
                        Date = @date,
                        StartTime = @start,
                        EndTime = @end,
                        Purpose = @purpose
                    WHERE BookingID = @id;";
                cmd.Parameters.AddWithValue("@id", b.BookingID);
                cmd.Parameters.AddWithValue("@room", b.RoomName);
                cmd.Parameters.AddWithValue("@booker", b.BookerName);
                cmd.Parameters.AddWithValue("@date", b.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@start", b.StartTime.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@end", b.EndTime.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@purpose", b.Purpose ?? string.Empty);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public static void DeleteBooking(string bookingId)
        {
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Bookings WHERE BookingID = @id;";
                cmd.Parameters.AddWithValue("@id", bookingId);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public static List<Booking> GetAllBookings()
        {
            var list = new List<Booking>();
            try
            {
                using var conn = new SqliteConnection(ConnectionString);
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT BookingID, RoomName, BookerName, Date, StartTime, EndTime, Purpose FROM Bookings;";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var b = new Booking
                    {
                        BookingID = reader.GetString(0),
                        RoomName = reader.GetString(1),
                        BookerName = reader.GetString(2),
                        Date = DateTime.Parse(reader.GetString(3)),
                        StartTime = TimeSpan.Parse(reader.GetString(4)),
                        EndTime = TimeSpan.Parse(reader.GetString(5)),
                        Purpose = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                    };
                    list.Add(b);
                }
            }
            catch
            {
                throw;
            }

            return list;
        }
    }
}