using Spectre.Console;
using static TCSA.OOP.LibraryManagementSystem.Enums;
using TCSA.OOP.LibraryManagementSystem.Controllers;

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
                    booksController.ViewItems();
                    break;
                case MenuOptions.AddBook:
                    booksController.AddItems();
                    break;
                case MenuOptions.DeleteBook:
                    booksController.DeleteItems();
                    break;
            }
        }
    }
}


