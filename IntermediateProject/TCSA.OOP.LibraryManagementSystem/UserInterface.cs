using Spectre.Console;
using static TCSA.OOP.LibraryManagementSystem.Enums;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using TCSA.OOP.LibraryManagementSystem.Controller;

namespace TCSA.OOP.LibraryManagementSystem;

internal class UserInterface
{
    private readonly BooksController _booksController = new(); // readonly means that the reference to the _booksController instance cannot be changed after it's assigned. This is a good practice for dependencies that should not be replaced during the lifetime of the UserInterface class.
    private readonly MagazineController _magazineController = new();
    private readonly NewspaperController _newspaperController = new();

    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            //Ansiconsole is a library for creating beautiful console applications in .NET.
            //It provides a rich set of features for formatting text, creating tables, progress bars, and more.
            //In this code snippet, we are using the `SelectionPrompt` class from the Spectre.Console library to create a menu for the user to choose from.
            var actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuAction>()
                .Title("What do you want to do next?")
                .AddChoices(Enum.GetValues<MenuAction>()));

            var itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>()
                .Title("Select the type of item:")
                .AddChoices(Enum.GetValues<ItemType>()));

            switch (actionChoice)
            {
                case MenuAction.ViewItem:
                     ViewItems(itemTypeChoice);
                    break;
                case MenuAction.AddItem:
                    AddItem(itemTypeChoice);
                    break;
                case MenuAction.DeleteItem:
                    DeleteItem(itemTypeChoice);
                    break;
            }
        }
    }

    private void ViewItems(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                _booksController.ViewItems();
                break;
            case ItemType.Magazine:
                _magazineController.ViewItems();
                break;
            case ItemType.Newspaper:
                _newspaperController.ViewItems();
                break;
        }
    }

    private void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                _booksController.AddItems();
                break;
            case ItemType.Magazine:
                _magazineController.AddItems();
                break;
            case ItemType.Newspaper:
                _newspaperController.AddItems();
                break;
        }
    }

    private void DeleteItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
            _booksController.DeleteItems();
            break;
            case ItemType.Magazine:
            _magazineController.DeleteItems();
            break;
            case ItemType.Newspaper:
            _newspaperController.DeleteItems();
            break;
        }
    }
       
}


