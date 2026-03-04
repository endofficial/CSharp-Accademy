using Spectre.Console;
using System.Globalization;

namespace CodingTracker.Controller;

internal class InputInsert
{
    public static bool GetDateSessionInput()
    {
        AnsiConsole.MarkupLine("Register a new session.");
        var date = AnsiConsole.Ask<string>("Please enter date (yyyy-MM-dd). You type [red]0[/] to return to main menu.");

        if (date == "0") return false;

        while (!DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("en-EN"), DateTimeStyles.None, out _))
        {
            AnsiConsole.MarkupLine("[red]Invalid date format.[/]");
            date = AnsiConsole.Ask<string>("Please enter date (yyyy-MM-dd). You type [red]0[/] to return to main menu.");
            if (date == "0") return false;
        }
        return true;
    }

    public static bool GetTimeSessionInput()
    {
        return true;
    }
}

