namespace ICS_SIS.BL.Models;

public record SubjectListModel() : ModelBase
{
    public required string Name { get; set; }

    public required string Acronym { get; set; }

    public static SubjectListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Acronym = string.Empty
    };
}