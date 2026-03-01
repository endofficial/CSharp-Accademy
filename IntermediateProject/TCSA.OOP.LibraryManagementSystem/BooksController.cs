using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem;

internal class BooksController
{
    private static List<string> books = new()
    {
        "The Great Gatsby",
        "To Kill a Mockingbird",
        "1984",
        "Pride and Prejudice",
        "The Catcher in the Rye"
    };

    internal void ViewBooks()
    {
        /* Spectre's MarkupLine method is useful for styling strings.
                We'll use it as a standard do print messages to the console.*/
        AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

        foreach (var book in books)
        {
            AnsiConsole.MarkupLine($"- [cyan]{book}[/]");
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

        //checking if the book already exists in the list
        if (books.Contains(title))
        {
            AnsiConsole.MarkupLine($"[red]The book '{title}' already exists in the list.[/]");
        }
        else
        {
            books.Add(title);
            AnsiConsole.MarkupLine($"[green]Book '{title}' added successfully![/]");
        }
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    internal void DeleteBook()
    {
        //checking if there are any books to delete
        if (books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        /* showing a list of books and letting the user choose with arrows 
        using SelectionPrompt, similarly to what we do with the menu */
        var bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Select a [red]book[/] to delete:")
            .AddChoices(books));

        /* Using the Remove method to delete a book. This method returns a boolean
        that we can use to present a message in case of success or failure.*/
        if (books.Remove(bookToDelete))
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
