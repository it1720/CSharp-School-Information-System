namespace ICS_SIS.DAL.Entities
{
    public record EvaluationEntity : IEntity
    {
        public Guid Id { get; set; }

        public double Points { get; set; }

        public string? Comment { get; set; }


        //Relations
        public Guid StudentId { get; set; }

        public required StudentEntity? Student { get; set; }

        public Guid ActivityId { get; set; }
        public required ActivityEntity? Activity { get; set; }
    }
}
