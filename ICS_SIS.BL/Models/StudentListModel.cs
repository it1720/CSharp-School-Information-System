namespace ICS_SIS.BL.Models;

public record StudentListModel : ModelBase
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }
    public string? PhotoUrl { get; set; }
    public static StudentListModel Empty => new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        PhotoUrl = string.Empty,
    };
}