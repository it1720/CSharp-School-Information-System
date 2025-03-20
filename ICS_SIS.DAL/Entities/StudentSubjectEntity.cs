namespace ICS_SIS.DAL.Entities
{
    public record StudentSubjectEntity : IEntity
    {
        public required Guid Id { get; set; }

        public required Guid StudentId { get; set; }

        public required Guid SubjectId { get; set; }

        public required StudentEntity? Student { get; init; }
        
        public required SubjectEntity? Subject { get; init; }
    }
}