using ICS_SIS.DAL.Enums;

namespace ICS_SIS.BL.Models;

public record ActivityListModel : ModelBase
{
    public required DateTime Start { get; set; }

    public required DateTime End { get; set; }

    public Room Place { get; set; }

    public ActivityType Type { get; set; }
    public required Guid SubjectId { get; set; }

    public static ActivityListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        Start = DateTime.UnixEpoch,
        End = DateTime.UnixEpoch,
    };
}