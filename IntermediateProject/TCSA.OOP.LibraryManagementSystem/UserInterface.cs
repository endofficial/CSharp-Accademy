using TCSA.OOP.LibraryManagementSystem.Models;
using Spectre.Console;
using static TCSA.OOP.LibraryManagementSystem.Enums;

namespace TCSA.OOP.LibraryManagementSystem;

internal class UserInterface
{
    private BooksController booksController = new BooksController();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            //Ansiconsole is a library for creating beautiful console applications in .NET.
            //It provides a rich set of features for formatting text, creating tables, progress bars, and more.
            //In this code snippet, we are using the `SelectionPrompt` class from the Spectre.Console library to create a menu for the user to choose from.
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What do you want to do next?")
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (choice)
            {
                case MenuOptions.ViewBooks:
                    booksController.ViewBooks();
                    break;
                case MenuOptions.AddBook:
                    booksController.AddBook();
                    break;
                case MenuOptions.DeleteBook:
                    booksController.DeleteBook();
                    break;
            }
        }
    }
}

internal static class MockDatabase
{
    internal static List<LibraryItem> LibraryItems = new()
    {
        new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction", "A1", 218),
        new Book(2, "To Kill a Mockingbird", "Harper Lee", "Fiction", "A2", 324),
        new Book(3, "1984", "George Orwell", "Dystopian", "A3", 328),
        new Book(4, "Pride and Prejudice", "Jane Austen", "Romance", "A4", 279),
        new Book(5, "The Catcher in the Rye", "J.D. Salinger", "Fiction", "A5", 214),

        new Magazine(1, "National Geographic", "National Geographic Partners", new DateTime(2024, 8, 1), "B1", 12),
        new Magazine(2, "Time", "Time USA, LLC", new DateTime(2024, 7, 15), "B2", 8),
        new Magazine(3, "The Economist", "The Economist Group", new DateTime(2024, 6, 10), "B3", 16),
        new Magazine(4, "Forbes", "Forbes Media", new DateTime(2024, 5, 20), "B4", 10),
        new Magazine(5, "Wired", "Condé Nast", new DateTime(2024, 4, 5), "B5", 15),

        new Newspaper(1, "The New York Times", "The New York Times Company", new DateTime(2024, 8, 18), "C1"),
        new Newspaper(2, "The Guardian", "Guardian Media Group", new DateTime(2024, 8, 17), "C2"),
        new Newspaper(3, "The Washington Post", "Nash Holdings", new DateTime(2024, 8, 16), "C3"),
        new Newspaper(4, "The Wall Street Journal", "Dow Jones & Company", new DateTime(2024, 8, 15), "C4"),
        new Newspaper(5, "USA Today", "Gannett", new DateTime(2024, 8, 14), "C5")    
    };
}

