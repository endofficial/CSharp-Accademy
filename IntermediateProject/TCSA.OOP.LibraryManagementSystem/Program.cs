using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem;

var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book"};

// Create a controller instance to call instance methods
var booksController = new BooksController();

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

//Un enum consente di definire un tipo che può accettare solo uno dei valori predefiniti.
//Questo limita i possibili valori che una variabile può contenere, riducendo gli errori.
//Sono particolarmente adatti per situazioni in cui si hanno solo poche opzioni.
enum MenuOptions
{
    ViewBooks,
    AddBook,
    DeleteBook
}

