namespace CodingTracker.Model;

internal class CodingSessions
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }

    public TimeSpan Duration => EndTime - StartTime;

    public CodingSessions(int id, DateTime startTime, DateTime endTime, TimeSpan duration, string? description)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        duration = Duration;
        Description = description;
    }
}

