using Microsoft.Data.SqlClient;
using soft20181_starter.DataAccess;
using soft20181_starter.Models;
using System.Data;

namespace soft20181_starter.Business_Logic
{
    public class EventOperation
    {
        public static void CreateBooking(Booking obj)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            string query = "INSERT INTO Bookings (Name, Phone, Tickets, Event, Location) VALUES" +
                "(@Name, @Phone, @Tickets, @Event, @Location)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Tickets", obj.Tickets);
            cmd.Parameters.AddWithValue("@Event", obj.Event);
            cmd.Parameters.AddWithValue("@Location", obj.Location);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static Booking GetBooking(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "SELECT * FROM Bookings WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Booking booking = null;

            if (reader.Read())
            {
                booking = new Booking();
                booking.Id = Convert.ToInt32(reader["Id"]);
                booking.Name = reader["Name"].ToString();
                booking.Phone = reader["Phone"].ToString();
                booking.Tickets = Convert.ToInt32(reader["Tickets"]);
                booking.Event = reader["Event"].ToString();
                booking.Location = reader["Location"].ToString();
            }
            con.Close();
            return booking;
        }
        public static List<Booking> GetBookings()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "SELECT * FROM Bookings";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Booking> bookings = new List<Booking>();
            while (reader.Read())
            {
                Booking p = new Booking();
                p.Id = Convert.ToInt32(reader["Id"]);
                p.Name = reader["Name"].ToString();
                p.Phone = reader["Phone"].ToString();
                p.Tickets = Convert.ToInt32(reader["Tickets"]);
                p.Event = reader["Event"].ToString();
                p.Location = reader["Location"].ToString();

                bookings.Add(p);
            }
            con.Close();
            return bookings;
        }
        public static void DeleteBooking(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "DELETE FROM Bookings WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateBooking(Booking obj)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "UPDATE Bookings SET Name=@Name, Phone=@Phone, Tickets=@Tickets, Event=@Event, Location=@Location" +
                " WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Tickets", obj.Tickets);
            cmd.Parameters.AddWithValue("@Event", obj.Event);
            cmd.Parameters.AddWithValue("@Location", obj.Location);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
