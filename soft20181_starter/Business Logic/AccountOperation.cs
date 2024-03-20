using Microsoft.Data.SqlClient;
using soft20181_starter.DataAccess;
using soft20181_starter.Models;

namespace soft20181_starter.Business_Logic
{
    public class AccountOperation
    {
        public static void CreateAccount(Account obj)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            string query = "INSERT INTO Accounts (Name, Email, Password, Role) VALUES " +
                "(@Name, @Email, @Password, @Role)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static Account CheckAccount(string e, string p) 
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Accounts WHERE Email=@Email AND Password=@Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", e);
            cmd.Parameters.AddWithValue("@Password", p);

            SqlDataReader reader = cmd.ExecuteReader();

            Account acc = null;

            if (reader.Read())
            {
                acc = new Account();
                acc.Id = Convert.ToInt32(reader["Id"]);
                acc.Name = reader["Name"].ToString();
                acc.Email = reader["Email"].ToString();
                acc.Password = reader["Password"].ToString();
                acc.Role = reader["Role"].ToString();
            }
            conn.Close();
            return acc;
        }
        public static Account GetAccount(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "SELECT * FROM Accounts WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Account acc = null;

            if (reader.Read())
            {
                acc = new Account();
                acc.Id = Convert.ToInt32(reader["Id"]);
                acc.Name = reader["Name"].ToString();
                acc.Email = reader["Email"].ToString();
                acc.Password = reader["Password"].ToString();
                acc.Role = reader["Role"].ToString();
            }
            con.Close();
            return acc;
        }
        public static List<Account> GetAccounts()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "SELECT * FROM Accounts";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Account> accounts = new List<Account>();
            while (reader.Read())
            {
                Account p = new Account();
                p.Id = Convert.ToInt32(reader["Id"]);
                p.Name = reader["Name"].ToString();
                p.Email = reader["Email"].ToString();
                p.Password = reader["Password"].ToString();
                p.Role = reader["Role"].ToString();

                accounts.Add(p);
            }
            con.Close();
            return accounts;
        }
        public static void DeleteAccount(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "DELETE FROM Accounts WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateAccounts(Account obj)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string query = "UPDATE Accounts " +
                "SET Name=@Name, Email=@Email, Password=@Password, Role=@Role " +
                "WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", obj.Id);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@Role", obj.Role);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
