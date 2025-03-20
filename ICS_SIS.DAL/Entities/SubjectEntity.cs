namespace ICS_SIS.DAL.Entities
{
    public record SubjectEntity : IEntity
    {
        public Guid Id { get; set; }
        
        public required string Name { get; set; }

        public required string Acronym { get; set;}


        //Relations
        public ICollection<StudentSubjectEntity> Students { get; init; } = new List<StudentSubjectEntity>();

        public ICollection<ActivityEntity> Activities { get; init; } = new List<ActivityEntity>();
    }
}
