using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Controllers;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controller;

internal class NewspaperController : IBaseController
{
    public void ViewItems()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Title[/]");
        table.AddColumn("[yellow]Publisher[/]");
        table.AddColumn("[yellow]Publish Date[/]");
        table.AddColumn("[yellow]Location[/]");

        var newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

        foreach (var newspaper in newspapers)
        {
            table.AddRow(
                newspaper.Id.ToString(),
                $"[cyan]{newspaper.Name}[/]",
                $"[cyan]{newspaper.Publisher}[/]",
                $"[cyan]{newspaper.PublishDate:yyyy-MM-dd}[/]",
                $"[cyan]{newspaper.Location}[/]"
            );
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void AddItems()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the newspaper to add:");
        var publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the newspaper to add:");
        var publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the newspaper to add (yyyy-MM-dd):");
        var location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the newspaper to add:");

        if (MockDatabase.LibraryItems.OfType<Newspaper>().Any(n => n.Name.Equals(title, StringComparison.OrdinalIgnoreCase))) //ordinalIgnoreCase to ignore case sensitivity
        {
            AnsiConsole.MarkupLine($"[red]This newspaper already exists.[/]");
        }
        else
        {
            var newNewspaper = new Newspaper(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location);
            MockDatabase.LibraryItems.Add(newNewspaper);
            AnsiConsole.MarkupLine($"[green]Newspaper added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteItems()
    {
        var newspaper = MockDatabase.LibraryItems.OfType<Newspaper>().ToList();

        if (newspaper.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No newspapers available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var newspaperToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Newspaper>()
            .Title("Select a [red]newspaper[/] to delete:")
            .UseConverter(n => $"{n.Name} (Published on {n.PublishDate:yyyy-MM-dd})")
            .AddChoices(newspaper)
        );

        if (MockDatabase.LibraryItems.Remove(newspaperToDelete))
        {
            AnsiConsole.MarkupLine($"[green]Newspaper '{newspaperToDelete.Name}' deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Failed to delete the newspaper.[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
        Console.ReadKey();
    }
}
