using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Models;

public class Book : LibraryItem
{
    public string Author { get; set; }
    public string Category { get; set; }
    public int Pages { get; set; }

    public Book(int id, string name, string author, string category, string location, int pages) : base(id, name, location)
    {
        Author = author;
        Category = category;
        Pages = pages;
    }

    public override void Displaydetails()
    {
        var panel = new Panel(new Markup($"[bold]Book:[/] [cyan]{Name}[/] by [cyan]{Author}[/]") +
                              $"\n[bold]Pages:[/] {Pages}" +
                              $"\n[bold]Category:[/] [green]{Category}[/]" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}

