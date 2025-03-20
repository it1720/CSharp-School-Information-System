using System.Collections.ObjectModel;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Enums;

namespace ICS_SIS.BL.Models;

public record ActivityDetailModel : ModelBase
{
    public required DateTime Start { get; set; }

    public required DateTime End { get; set; }

    public Room Place { get; set; }

    public ActivityType Type { get; set; }

    public string? Description { get; set; }
    public required Guid SubjectId { get; set; }

    public ObservableCollection<EvaluationListModel> Evaluations { get; set; } = new();

    public static ActivityDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        Start = DateTime.UnixEpoch,
        End = DateTime.UnixEpoch,
        Description = string.Empty,
    };
}