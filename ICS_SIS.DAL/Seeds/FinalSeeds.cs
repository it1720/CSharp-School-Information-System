using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_SIS.DAL.Seeds;

public static class FinalSeeds
{
    static FinalSeeds()
    {
    }

    public static void SeedAdditionalData(ModelBuilder modelBuilder)
    {
        SubjectSeeds.Izlo.Students.Add(StudentSubjectSeeds.IzloPerson1);
        SubjectSeeds.Izlo.Students.Add(StudentSubjectSeeds.IzloPerson2);
        SubjectSeeds.Izlo.Activities.Add(ActivitySeeds.Aktivita);
        StudentSeeds.Person1.Subjects.Add(StudentSubjectSeeds.IzloPerson1);
        StudentSeeds.Person2.Subjects.Add(StudentSubjectSeeds.IzloPerson2);
        StudentSeeds.Person1.Evaluations.Add(EvalutionSeeds.Eval);
        ActivitySeeds.Aktivita.Evaluations.Add(EvalutionSeeds.Eval);
    }
}
