using System.Collections.ObjectModel;

namespace ICS_SIS.BL.Models;

public record StudentDetailModel() : ModelBase
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? PhotoUrl { get; set; }
    public ObservableCollection<StudentSubjectListModel> Subjects { get; set; } = new();
    public ObservableCollection<EvaluationListModel> Evaluations { get; set; } = new();

    public static StudentDetailModel Empty => new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        PhotoUrl = string.Empty,
    };
}