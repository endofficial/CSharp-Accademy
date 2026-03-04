using CodingTracker.Data;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new();
            database.Initialize();

            UserInterface ui = new();
            ui.MainMenu();
        }
    }
}
