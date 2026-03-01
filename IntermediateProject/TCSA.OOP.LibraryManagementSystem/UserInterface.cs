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
    internal static List<string> Books = new()
    {
        "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
    };
}

//Un enum consente di definire un tipo che può accettare solo uno dei valori predefiniti.
//Questo limita i possibili valori che una variabile può contenere, riducendo gli errori.
//Sono particolarmente adatti per situazioni in cui si hanno solo poche opzioni.
internal class Enums
{
    internal enum MenuOptions
    {
        ViewBooks,
        AddBook,
        DeleteBook
    }
}