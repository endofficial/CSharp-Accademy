namespace CodingTracker
{
    internal class Program
    {
        private static readonly string connectionString = "Data Source=CodingTracker.db";
        static void Main(string[] args)
        {
            UserInterface ui = new();
            ui.MainMenu();
        }
    }
}
