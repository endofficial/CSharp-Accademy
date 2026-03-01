using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

public class BooksController : IBaseController
{
    public void ViewItems()
    {
        /*Spectre's MarkupLine method is useful for styling strings.
         We'll use it as a standard do print messages to the console.
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        var books = MockDatabase.LibraryItems.OfType<Book>();

        foreach (var book in books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();*/

        var table = new Table();
        table.Border(TableBorder.Rounded);

        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Author[/]");
        table.AddColumn("[yellow]Category[/]");
        table.AddColumn("[yellow]Location[/]");
        table.AddColumn("[yellow]Pages[/]");

        var books = MockDatabase.LibraryItems.OfType<Book>();

        foreach (var book in books)
        {
            table.AddRow(
                book.Id.ToString(),
                $"[cyan]{book.Name}[/]",
                $"[cyan]{book.Author}[/]",
                $"[green]{book.Category}[/]",
                $"[blue]{book.Location}[/]",
                book.Pages.ToString()
                );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void AddItems()
    {
        /*Spectre's Ask<> method allows us to prompt a message to grab 
        the user's input. We can pass the type we expect as an answer
        for validation. We're storing the answer in the 'title' variable

        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] of the book to add:");

        //checking if the book already exists in the list
        if (MockDatabase.Books.Exists(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine($"[red]The book '{title}' already exists in the list.[/]");
        }
        else
        {
            var newBook = new Book(title, pages);
            MockDatabase.Books.Add(newBook);
            AnsiConsole.MarkupLine($"[green]Book '{title}' added successfully![/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();*/

        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
        var author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book to add:");
        var category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book to add:");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book to add:");
        var pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] of the book to add:");

        if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine($"[red]The book '{title}' already exists in the list.[/]");
        }
        else
        {
            var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages); // we set the id of the book as the count of library items + 1 to ensure uniqueness
            MockDatabase.LibraryItems.Add(newBook);
            AnsiConsole.MarkupLine($"[green]Book '{title}' added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteItems()
    {
        /*//checking if there are any books to delete
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        showing a list of books and letting the user choose with arrows 
        using SelectionPrompt, similarly to what we do with the menu 
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
            .Title("Select a [red]book[/] to delete:")
            .UseConverter(b => $"{b.Name}") // this is to show only the name of the book in the selection list
            .AddChoices(MockDatabase.Books)); // we pass the list of books as choices for the selection prompt

        /* Using the Remove method to delete a book. This method returns a boolean
        that we can use to present a message in case of success or failure.
        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to delete the book.[/]");
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();*/

        var books = MockDatabase.LibraryItems.OfType<Book>().ToList(); // we get the list of books from the library items

        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
            .Title("Select a [red]book[/] to delete:")
            .UseConverter(b => $"{b.Name}")
            .AddChoices(books));

        if (MockDatabase.LibraryItems.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Failed to delete the book.[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}
