using MySqlConnector;
using System.Data;
namespace finalprojectjosephkafekecprg211.Data
{
    public class Dbservi
    {
        private readonly string _connectionString;
        public Dbservi()
        {
            _connectionString = Dbconfig.GetConnectionString();
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        public async Task<DataTable> GetMembersAsync()
        {
            var dt = new DataTable();
            using var connection = GetConnection();
            await connection.OpenAsync();
            using var cmd = new MySqlCommand("SELECT * FROM Members", connection);
            using var reader = await cmd.ExecuteReaderAsync();
            dt.Load(reader);
            return dt;
        }
        public async Task<List<Staff>> GetStaffListAsync()
        {
            var staffList = new List<Staff>();
            using var conn = GetConnection();
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Staff", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                staffList.Add(new Staff
                {
                    StaffID = reader.GetInt32("StaffID"),
                    Name = reader.GetString("Name"),
                    Role = reader.GetString("Role")
                });
            }
            return staffList;
        }
        public async Task<List<WorkoutClass>> GetWorkoutClassesAsync()
        {
            var classList = new List<WorkoutClass>();
            using var conn = GetConnection();
            await conn.OpenAsync();
            var cmd = new MySqlCommand(@"
       SELECT wc.ClassID, wc.Title, wc.Schedule, s.Name AS TrainerName
       FROM workoutclasses wc
       JOIN staff s ON wc.TrainerID = s.StaffID", conn);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                classList.Add(new WorkoutClass
                {
                    ClassID = reader.GetInt32("ClassID"),
                    Title = reader.GetString("Title"),
                    Schedule = reader.GetDateTime("Schedule"),
                    TrainerName = reader.GetString("TrainerName")
                });
            }
            return classList;
        }
        public async Task<List<Member>> GetMembersListAsync()
        {
            var members = new List<Member>();
            using var connection = GetConnection();
            await connection.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Members", connection);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                members.Add(new Member
                {
                    ID = reader.GetInt32("MemberID"),
                    FullName = reader.GetString("Name"),
                    JoinDate = reader.GetDateTime("JoinDate"),
                    MembershipExpires = reader.GetDateTime("MembershipEnd")
                });
            }
            return members;
        }
    }
}