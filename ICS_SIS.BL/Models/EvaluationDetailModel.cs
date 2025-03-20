namespace ICS_SIS.BL.Models;

public record EvaluationDetailModel : ModelBase
{
    public double Points { get; set; }

    public string? Comment { get; set; }

    public Guid StudentId { get; set; }
    public Guid ActivityId { get; set; }

    public static EvaluationDetailModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Points = 0.0,
        Comment = string.Empty,
        ActivityId = Guid.Empty,
        StudentId = Guid.Empty,
    };
}