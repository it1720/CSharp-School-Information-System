using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_SIS.DAL.Entities
{
    public record StudentEntity : IEntity
    {
        public Guid Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? PhotoUrl { get; set; }


        //Relations
        public ICollection<StudentSubjectEntity> Subjects { get; set; } = new List<StudentSubjectEntity>();

        public ICollection<EvaluationEntity> Evaluations { get; set; } = new List<EvaluationEntity>();
    }
}
