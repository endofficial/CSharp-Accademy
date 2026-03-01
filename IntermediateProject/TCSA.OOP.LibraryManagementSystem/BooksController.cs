using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal class BooksController
{
    internal void ViewBooks()
    {
        /* Spectre's MarkupLine method is useful for styling strings.
                We'll use it as a standard do print messages to the console.*/
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    internal void AddBook()
    {
        /* Spectre's Ask<> method allows us to prompt a message to grab 
                the user's input. We can pass the type we expect as an answer
                for validation. We're storing the answer in the 'title' variable*/

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
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        //checking if there are any books to delete
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        /* showing a list of books and letting the user choose with arrows 
        using SelectionPrompt, similarly to what we do with the menu */
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
            .Title("Select a [red]book[/] to delete:")
            .UseConverter(b => $"{b.Name}") // this is to show only the name of the book in the selection list
            .AddChoices(MockDatabase.Books)); // we pass the list of books as choices for the selection prompt

        /* Using the Remove method to delete a book. This method returns a boolean
        that we can use to present a message in case of success or failure.*/
        if (MockDatabase.Books.Remove(bookToDelete))
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
