namespace Habit_tracker;

public class Menu
{
    public static void GetUserInput()
    {
        bool closeApp = false;

        while (!closeApp)
        {
            WriteLine("\nWELCOME IN YOUR HABIT TRACKER!");
            WriteLine("\nWHAT WOULD YOU LIKE TO DO?");
            WriteLine("\nTYPE 0 TO CLOSE APP");
            WriteLine("TYPE 1 TO ADD A NEW HABIT ENTRY");
            WriteLine("TYPE 2 TO UPDATE RECORD");
            WriteLine("TYPE 3 TO DELETE RECORD");
            WriteLine("TYPE 4 TO SEE ALL RECORDS");

            string? userInput = ReadLine();

            while (!Int32.TryParse(userInput, out _) || Convert.ToInt32(userInput) < 0 || Convert.ToInt32(userInput) > 4)
            {
                WriteLine("\nINVALID INPUT, PLEASE TRY AGAIN:");
                userInput = ReadLine();
            }

            switch (userInput)
            {
                case "0":
                    closeApp = true;
                    break;
                case "1":
                    DatabaseManager.Insert();
                    break;
                case "2":
                    DatabaseManager.Update();
                    break;
                case"3":
                    DatabaseManager.Delete();
                    break;
                case "4":
                    DatabaseManager.GetAllrecords();
                    break;
            }
        }
    }
}