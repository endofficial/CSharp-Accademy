using Microsoft.Data.Sqlite;
using System.Globalization;

namespace Habit_tracker;

public class DatabaseManager
{
    static string connectionString = @"Data Source=habit-tracker.db";

    public static void Register()
    {
        Console.Clear();
        string nameHabit = InputInsert.GetNewHabitInput(Console.In);

        string unitOfMeasure = InputInsert.GetNewUnitOfMeasureInput(Console.In);
    }

    public static void Insert()
    {
        Console.Clear();
        string date = InputInsert.GetDateInput(Console.In);

        if (int.TryParse(date, out int insertDate))
        {
            if (insertDate == 0) return;
        }

        int quantity = InputInsert.GetNumberInput("\nPLEASE ENTER HOW MANY TIMES HAVE YOU DRINK COFFEE? TYPE 0 TO RETURN TO MAIN MENU.", Console.In);

        if (quantity == 0) return;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"INSERT INTO drinking_water(date, quantity) VALUES('{date}', {quantity})";
            tableCmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public static void GetAllrecords()
    {
        Console.Clear();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = "SELECT * FROM drinking_water"; // SQL query to select all records

            List<DrinkingWater> tableData = new List<DrinkingWater>();

            SqliteDataReader reader = tableCmd.ExecuteReader(); // Execute the query and get a reader; ExecuteReader is used for SELECT statements

            if (reader.HasRows) // Check if there are any rows
            {
                while (reader.Read())
                {
                    tableData.Add(
                    new DrinkingWater
                    {
                        Id = reader.GetInt32(0), // Get the value of the first column (Id)
                        Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None), // Get the value of the second column (Date)
                        Quantity = reader.GetInt32(2) // Get the value of the third column (Quantity)
                    });
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }

            connection.Close();

            WriteLine("-------------------------------------------------------");
            foreach (var db in tableData)
            {
                WriteLine($"ID: {db.Id} - {db.Date.ToString("dd-MM-yy")} - QUANTITY: {db.Quantity}");
            }
            WriteLine("-------------------------------------------------------");
        }
    }

    public static void Update()
    {
        GetAllrecords();
        bool continueUpdate = true;

        while (continueUpdate)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText = "SELECT * FROM drinking_water"; // SQL query to select all records
                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (!reader.HasRows) // Check if there are any rows
                {
                    WriteLine("\nNO RECORDS TO UPDATE.");
                    connection.Close();
                    continueUpdate = false;
                }

                else
                {
                    var recordId = InputInsert.GetNumberInput("\nPLEASE ENTER THE ID OF THE RECORD YOU WANT TO UPDATE. TYPE 0 TO RETURN TO MAIN MENU.", Console.In);
                    if (recordId == 0)
                    {
                        connection.Close();
                        return;
                    } 
                    else
                    {
                        tableCmd = connection.CreateCommand();
                        tableCmd.CommandText = $"SELECT EXISTS (SELECT 1 FROM drinking_water WHERE Id = {recordId})";

                        var checkQuery = Convert.ToInt32(tableCmd.ExecuteScalar()); // ExecuteScalar is used to get a single value, it used to ceck if the record exists
                        if (checkQuery == 0)
                        {
                            WriteLine("\nRECORD NOT FOUND.");
                            connection.Close();
                            Update();
                        }

                        string upDate = InputInsert.GetDateInput();

                        if (int.TryParse(upDate, out int upMenu))
                        {
                            if (upMenu == 0)
                            {
                                connection.Close();
                                return;
                            }
                        }

                        int upQuantity = InputInsert.GetNumberInput("\nPLEASE ENTER NEW COFFE QUANITTY. TYPE 0 TO RETURN TO MAIN MENU.");

                        if (upQuantity == 0)
                        {
                            connection.Close();
                            return;
                        }

                        tableCmd.CommandText = $"UPDATE drinking_water SET Date = '{upDate}', Quantity = {upQuantity} WHERE Id = {recordId}";
                        tableCmd.ExecuteNonQuery();
                        connection.Close();
                        continueUpdate = false;
                    }
                }
            }
        }
    }

    public static void Delete()
    {
        Console.Clear();
        GetAllrecords();

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = "SELECT * FROM drinking_water"; // SQL query to select all records

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (!reader.HasRows) // Check if there are any rows
            {
                WriteLine("\nNO RECORDS TO DELETE.");
                connection.Close();
                return;
            }
            else 
            {
                WriteLine("\nTYPE 'D' TO DELETE ALL RECORDS. PRESS 'C' TO SELECT THE RECORD. PRESS 0 TO RETURN TO MAIN MENU.");

                string? delInput = ReadLine()?.ToUpper();
                bool inputValid = false;

                do
                {
                    if (Int32.TryParse(delInput, out int numberInput))
                    {
                        if (numberInput == 0)
                        {
                            return;
                        }
                    }

                    if ((delInput == "D"))
                    {
                        tableCmd = connection.CreateCommand();
                        tableCmd.CommandText = $"DELETE FROM drinking_water";
                        int rowCount = tableCmd.ExecuteNonQuery();
                        connection.Close();
                        inputValid = true;

                    }
                    else if (delInput == "C")
                    {
                        var recordId = InputInsert.GetNumberInput("" +
                        "\nPLEASE ENTER THE ID OF THE RECORD YOU WANT TO DELETE. TYPE 0 TO RETURN TO MAIN MENU.");

                        if (recordId == 0) return;

                        tableCmd = connection.CreateCommand();
                        tableCmd.CommandText = $"DELETE FROM drinking_water WHERE Id = {recordId}";

                        int rowCount = tableCmd.ExecuteNonQuery(); // ExecuteNonQuery is used for DELETE statements

                        connection.Close();
                        inputValid = true;
                    }
                    else
                    {
                        WriteLine("\nINVALID INPUT. PLEASE TRY AGAIN.");
                        delInput = ReadLine()?.ToUpper();
                    }
                } while (!inputValid);

            }
        }
    }
}