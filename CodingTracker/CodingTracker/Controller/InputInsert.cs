using Spectre.Console;
using System.Globalization;

namespace CodingTracker.Controller;

internal class InputInsert
{
    public static bool GetDateSessionInput()
    {
        AnsiConsole.MarkupLine("Register a new session.");
        var date = AnsiConsole.Ask<string>("Please enter date (yyyy-MM-dd). You type [yellow]0[/] to return to main menu.");

        if (date == "0") return false;

        while (!DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("en-EN"), DateTimeStyles.None, out _))
        {
            AnsiConsole.MarkupLine("[red]Invalid date format.[/]");
            date = AnsiConsole.Ask<string>("Please enter date (yyyy-MM-dd). You type [yellow]0[/] to return to main menu.");
            if (date == "0") return false;
        }
        return true;
    }

    public static bool GetTimeSessionInput()
    {
        string durationInput = AnsiConsole.Prompt(
            new TextPrompt<string>("[grey bold]Please insert the duration (Format: [green]hh:mm[/]) or type [yellow]0[/] to return to main menu.")
            .Validate(input =>
            {
                if (input == "0") return ValidationResult.Success();

                bool isValid = TimeSpan.TryParseExact(input, @"h/:mm", CultureInfo.InvariantCulture, out var time);

                // Check if the time is valid and within the range of 0 to 24 hours
                if (!isValid) return ValidationResult.Error("[red]Duration invalid! Use the time format '[orange]hh:mm[/]'[/]");

                if (time.Ticks < 0) return ValidationResult.Error("[red]Negative time not allowed.[/]");

                return ValidationResult.Success();
            }));
        if (durationInput == "0") return false;

        return true;
    }
}

