using System.Collections.ObjectModel;

namespace ICS_SIS.BL.Models;

public record SubjectDetailModel() : ModelBase
{
    public required string Name { get; set; }

    public required string Acronym { get; set; }

    public ObservableCollection<ActivityListModel> Activities { get; set; } = new();
    public ObservableCollection<StudentSubjectListModel> Students { get; set; } = new();
    public static SubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Name = string.Empty,
        Acronym = string.Empty
    };
}