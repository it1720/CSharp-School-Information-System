namespace ICS_SIS.BL.Models;

public record StudentSubjectListModel() : ModelBase
{
    public required Guid StudentId { get; set; }
    public required string StudentFirstName { get; set; }
    public required string StudentLastName { get; set; }
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectAcronym { get; set; }

    public static StudentSubjectListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        SubjectId = Guid.Empty,
        StudentId = Guid.Empty,
        StudentFirstName = string.Empty,
        StudentLastName = string.Empty,
        SubjectName = string.Empty,
        SubjectAcronym = string.Empty,
    };
}