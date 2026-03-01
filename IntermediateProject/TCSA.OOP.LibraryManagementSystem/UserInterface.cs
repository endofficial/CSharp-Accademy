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
    internal static List<Book> Books = new()
    {
        new Book("The Great Gatsby", 180),
        new Book("To Kill a Mockingbird", 281),
        new Book("1984", 328),
        new Book("Pride and Prejudice", 432),
        new Book("The Catcher in the Rye", 277),
        new Book("The Hobbit", 310),
        new Book("Moby-Dick", 585),
        new Book("War and Peace", 1225),
        new Book("The Odyssey", 400),
        new Book("The Lord of the Rings", 1178),
        new Book("Jane Eyre", 500),
        new Book("Animal Farm", 112),
        new Book("Brave New World", 268),
        new Book("The Chronicles of Narnia", 768),
        new Book("The Diary of a Young Girl", 283),
        new Book("The Alchemist", 208),
        new Book("Wuthering Heights", 400),
        new Book("Fahrenheit 451", 158),
        new Book("Catch-22", 453),
        new Book("The Hitchhiker's Guide to the Galaxy", 224)    };
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