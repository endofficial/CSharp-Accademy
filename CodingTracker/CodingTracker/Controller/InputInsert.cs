using CodingTracker.Model;
using Spectre.Console;
using System.Globalization;

namespace CodingTracker.Controller;

internal class InputInsert
{
    internal static bool GetDateSessionInput()
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

    internal static bool GetTimeSessionInput()
    {
        string[] format = { @"h\:mm", @"hh\:mm" };
        string description = AnsiConsole.Ask<string>("Please enter a description for the session. You can leave it empty if you want.");

        string startInput = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold]Please insert the start time (Format: [green]hh:mm[/]) or type [yellow]0[/] to return to main menu.[/]")
            .Validate(input =>
            {
                if (input == "0") return ValidationResult.Success();

                bool isValid = TimeSpan.TryParseExact(input, format, CultureInfo.InvariantCulture, out var time);

                // Check if the time is valid and within the range of 0 to 24 hours
                if (!isValid) return ValidationResult.Error("[red]Time invalid! Use the time format '[blue]hh:mm[/]'[/]");

                if (time.Ticks < 0) return ValidationResult.Error("[red]Negative time not allowed.[/]");

                return ValidationResult.Success();
            }));
        if (startInput == "0") return false;

        string endInput = AnsiConsole.Prompt(
            new TextPrompt<string>("[bold]Please insert the end time (Format: [green]hh:mm[/]) or type [yellow]0[/] to return to main menu.[/]")
            .Validate(input =>
            {
                if (input == "0") return ValidationResult.Success();

                string[] format = { @"h\:mm", @"hh\:mm" };
                bool isValid = TimeSpan.TryParseExact(input, format, CultureInfo.InvariantCulture, out var time);

                // Check if the time is valid and within the range of 0 to 24 hours
                if (!isValid) return ValidationResult.Error("[red]Time invalid! Use the time format '[blue]hh:mm[/]'[/]");

                if (time.Ticks < 0) return ValidationResult.Error("[red]Negative time not allowed.[/]");

                return ValidationResult.Success();
            }));
        if (endInput == "0") return false;

        // convert string to DateTime
        DateTime startTime = DateTime.ParseExact(startInput, format, CultureInfo.InvariantCulture);
        DateTime endTime = DateTime.ParseExact(endInput, format, CultureInfo.InvariantCulture);

        // calculate duration
        TimeSpan duration = endTime - startTime;

        var session = new CodingSessions(0, startTime, endTime, duration, description);

        return true;
    }
}

