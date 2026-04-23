namespace RegisterApp.Api.Models;

public class VisitDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Patient { get; set; }
    public string Type { get; set; } = string.Empty;
}
