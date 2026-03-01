using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem.Controller;

public abstract class BaseController
{
    protected void DisplayMessage(string message, string color = "yellow")
    {
        AnsiConsole.MarkupLine($"[{color}]{message}[/]");
    }

    protected bool ConfirmDeletion(string itemName)
    {
        var confirm = AnsiConsole.Confirm($"Are you sure you want to delete [red]{itemName}[/]?"); // This will display a confirmation prompt to the user and return true if they confirm, or false if they cancel.

        return confirm;
    }
}

