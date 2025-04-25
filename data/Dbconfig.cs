using MySqlConnector;
namespace finalprojectjosephkafekecprg211.Data
{
    public static class Dbconfig
    {
        public static string GetConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "password",
                Database = "gymdb"
            };
            return builder.ConnectionString;
        }
    }
}
