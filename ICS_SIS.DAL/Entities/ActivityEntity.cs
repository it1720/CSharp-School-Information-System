using ICS_SIS.DAL.Enums;

namespace ICS_SIS.DAL.Entities
{
    public record ActivityEntity : IEntity
    {
        public Guid Id { get; set; }

        public required DateTime Start { get; set; }

        public required DateTime End { get; set; }

        public Room Place { get; set; }

        public ActivityType Type { get; set; }

        public string? Description { get; set; }


        //Relations
        public ICollection<EvaluationEntity> Evaluations { get; init; } = new List<EvaluationEntity>();

        public Guid SubjectId { get; set; }

        public required SubjectEntity? Subject { get; init; }
    }
}
