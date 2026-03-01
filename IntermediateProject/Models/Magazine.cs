using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Models;

internal class Magazine : LibraryItem
{
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public int IssueNumber { get; set; }

    public Magazine(int id, string name, string publisher, DateTime publishDate, string location, int issueNumber) : base(id, name, location)
    {
        Publisher = publisher;
        PublishDate = publishDate;
        IssueNumber = issueNumber;
    }

    public override void Displaydetails()
    {
        var panel = new Panel(new Markup($"[bold]Magazine:[/] [cyan]{Name}[/]") +
                              $"\n[bold]Publisher:[/] [green]{Publisher}[/]" +
                              $"\n[bold]Publish Date:[/] {PublishDate:MMMM dd, yyyy}" +
                              $"\n[bold]Issue Number:[/] {IssueNumber}" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}

