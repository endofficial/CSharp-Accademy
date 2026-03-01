using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers;

internal class MagazineController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded); 
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Issue Number[/]");
        table.AddColumn("[yellow]Location[/]");

        var magazines = MockDatabase.LibraryItems.OfType<Magazine>();

        foreach (var magazine in magazines)
        {
            table.AddRow(
                magazine.Id.ToString(), // ID is an integer, so we convert it to string
                $"[cyan]{magazine.Name}[/]",
                $"[cyan]{magazine.Publisher}[/]",
                $"[cyan]{magazine.PublishDate:yyyy-MM-dd}[/]",
                magazine.IssueNumber.ToString(), // Issue number is an integer, so we convert it to string
                $"[blue]{magazine.Location}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void AddItems()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the magazine to add:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the magazine to add:");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the magazine to add (yyyy-MM-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the magazine to add:");
        var issueNumber = AnsiConsole.Ask<int>("Enter the [green]issue number[/] of the magazine to add:");

        if (MockDatabase.LibraryItems.OfType<Magazine>().Any(m => m.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            AnsiConsole.MarkupLine($"[red]This magazine already exists.[/]");
        }
        else 
        {
            var newMagazine = new Magazine(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location, issueNumber);
            MockDatabase.LibraryItems.Add(newMagazine);
            AnsiConsole.MarkupLine($"[green]Magazine added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteItems()
    {
        var magazines = MockDatabase.LibraryItems.OfType<Magazine>().ToList();

        if (magazines.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No magazines available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var magazineToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Magazine>()
            .Title("Select a [red]magazine to delete:")
            .UseConverter(m => $"{m.Name} (Issue {m.IssueNumber})")
            .AddChoices(magazines));

        if (MockDatabase.LibraryItems.Remove(magazineToDelete))
        {
            AnsiConsole.MarkupLine($"[green]Magazine '{magazineToDelete.Name}' deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Failed to delete magazine '{magazineToDelete.Name}'.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}
