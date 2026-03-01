using Spectre.Console;
using System.Transactions;

var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book"};

var books = new List<string>()
{
    "The Great Gatsby",
    "To Kill a Mockingbird",
    "1984",
    "Pride and Prejudice",
    "The Catcher in the Rye"
};

while (true)
{
    Console.Clear();

    //Ansiconsole is a library for creating beautiful console applications in .NET.
    //It provides a rich set of features for formatting text, creating tables, progress bars, and more.
    //In this code snippet, we are using the `SelectionPrompt` class from the Spectre.Console library to create a menu for the user to choose from.
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("What do you want to do next?")
        .AddChoices(menuChoices));

    switch (choice)
    {
        case "MenuOptions.View Books":
            ViewBooks();
            break;
        case "MenuOptions.Add Book":
            AddBook();
            break;
        case "MenuOptions.Delete Book":
            DeleteBook();
            break;
    }
}

void ViewBooks()
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

void AddBook()
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

void DeleteBook()
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

//Un enum consente di definire un tipo che può accettare solo uno dei valori predefiniti.
//Questo limita i possibili valori che una variabile può contenere, riducendo gli errori.
//Sono particolarmente adatti per situazioni in cui si hanno solo poche opzioni.
enum MenuOptions
{
    ViewBooks,
    AddBook,
    DeleteBook
}

