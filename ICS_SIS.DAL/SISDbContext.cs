using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL
{
    public class SISDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
    {
        public DbSet<StudentEntity> Students => Set<StudentEntity>();
        public DbSet<StudentSubjectEntity> StudentSubjects => Set<StudentSubjectEntity>();
        public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();
        public DbSet<EvaluationEntity> Evaluations => Set<EvaluationEntity>();
        public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentSubjectEntity>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentEntity>()
                .HasMany(s => s.Evaluations)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityEntity>()
                .HasMany(a => a.Evaluations)
                .WithOne(e => e.Activity)
                .HasForeignKey(e => e.ActivityId);

            modelBuilder.Entity<SubjectEntity>()
                .HasMany(s => s.Activities)
                .WithOne(a => a.Subject)
                .HasForeignKey(a => a.SubjectId);

            if (seedDemoData) 
            {
                //demoScenario
                StudentSeeds.Seed(modelBuilder);
                StudentSubjectSeeds.Seed(modelBuilder);
                SubjectSeeds.Seed(modelBuilder);
                ActivitySeeds.Seed(modelBuilder);
                EvalutionSeeds.Seed(modelBuilder);
                FinalSeeds.SeedAdditionalData(modelBuilder);
            }
        }
    }
}
