using System.Collections.ObjectModel;

namespace ICS_SIS.BL.Models;

public record StudentSubjectDetailModel : ModelBase
{
    public required Guid StudentId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectAcronym { get; set; }
    public string? StudentPhotoUrl { get; set; }

    public static StudentSubjectDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        StudentId = Guid.Empty,
        SubjectId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty,
        SubjectName = string.Empty,
        SubjectAcronym = string.Empty,
    };

}