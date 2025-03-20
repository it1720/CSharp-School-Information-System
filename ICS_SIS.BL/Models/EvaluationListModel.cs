namespace ICS_SIS.BL.Models;

public record EvaluationListModel : ModelBase
{
    public double Points { get; set; }

    public Guid StudentId { get; set; }
    public Guid ActivityId { get; set; }


    public static EvaluationListModel Empty => new()
    {
        Id = Guid.NewGuid(),
        Points = 0.0,
        StudentId = Guid.Empty,
        ActivityId = Guid.Empty,
    };
}