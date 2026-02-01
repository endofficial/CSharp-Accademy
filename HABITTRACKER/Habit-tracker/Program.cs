using Microsoft.Data.Sqlite;

namespace Habit_tracker
{
    internal class Program
    {
        static string connectionString = @"Data Source=Habit-tracker.db";
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Habit (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Date TEXT,
                Quantity INTEGER,
                HabitId INTEGER);

                CREATE TABLE IF NOT EXISTS Register_Habit (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name_Habit TEXT,
                Unit_Of_Measurement TEXT)";

                tableCmd.ExecuteNonQuery();
                connection.Close();
            }

            Menu.GetUserInput();
        }
    }
}
