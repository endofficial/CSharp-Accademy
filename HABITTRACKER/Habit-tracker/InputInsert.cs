using System.Globalization;

namespace Habit_tracker;

public class InputInsert
{
    public static string GetDateInput(TextReader? reader = null)
    {
        reader ??= Console.In;
        WriteLine("\nPLEASE ENTER DATE (dd-MM-yy). TYPE 0 TO RETURN TO MAIN MENU. ");
        string? userInputDate = reader?.ReadLine()?.Trim();
        if (userInputDate == "0") return "0";

        while (!DateTime.TryParseExact(userInputDate, "dd-MM-yy", new CultureInfo("it-IT"),
              DateTimeStyles.None, out _))
        {
            WriteLine("\nINVALID DATE FORMAT. PLEASE ENTER DATE IN FORMAT (dd-MM-yy). TYPE 0 TO RETURN TO MAIN MENU.");
            userInputDate = reader?.ReadLine()?.Trim();
            if (userInputDate == "0") return "0";
        }
        return userInputDate!; // the ! operator is used to indicate that userInputDate is not null here
    }

    public static int GetNumberInput(string message, TextReader? reader = null)
    {
        WriteLine(message);
        string? userInputNumber = reader?.ReadLine()?.Trim();
        if (userInputNumber == "0") return 0;

        while (!Int32.TryParse(userInputNumber, out _) || Convert.ToInt32(userInputNumber) < 0)
        {
            WriteLine("\nINVALID NUMBER. PLEASE ENTER A VALID NUMBER. TYPE 0 TO RETURN TO MAIN MENU.");
            userInputNumber = reader?.ReadLine()?.Trim();
            if (userInputNumber == "0") return 0;
        }

        int finalInputNumber = Convert.ToInt32(userInputNumber);
        return finalInputNumber!;
    }
}

public class DrinkingWater
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}