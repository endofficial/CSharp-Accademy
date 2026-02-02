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

                #region To register some habits 

                (string Col1, string Col2)[] arrayDb = new (string, string)[]
                    { ("DRINKING COFFEE", "NUMBER OF CUPS"),
                      ("READING BOOKS", "NUMBER OF PAGES"),
                      ("RUNNING", "KILOMETERS"),
                      ("MEDITATION", "MINUTES"),
                      ("WATER INTAKE", "LITERS") };

                connection.Open();

                foreach (var dbArray in arrayDb)
                {
                    string query =
                    $"INSERT INTO Register_Habit (Name_Habit, Unit_Of_Measurement) VALUES(@val1, @val2)";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@val1", dbArray.Col1); // Name_Habit
                        command.Parameters.AddWithValue("@val2", dbArray.Col2); // Unit_Of_Measurement

                        command.ExecuteNonQuery();
                    }
                }

                #endregion
            }

            Menu.GetUserInput();
        }
    }
}
