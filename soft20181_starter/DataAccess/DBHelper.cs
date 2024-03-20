using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;

namespace soft20181_starter.DataAccess
{
    public class DBHelper : IdentityDbContext
    {
        public DBHelper(DbContextOptions<DBHelper> options) : base(options)
        {

        }
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=db_eventXplorer;Integrated Security=True;Trust Server Certificate=True");
            return conn;
        }
    }
}
