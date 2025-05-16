using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace StudyPlan.Model;

public class StudyPlanContext : DbContext
{
    public StudyPlanContext() : base() {}
    
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
}

public class Plan
{
    public string Name { get; set; }
    public EducationLevel EducationLevel { get; set; }
    
    public int YearsOfEducation { get; set; }

    public ObservableCollection<Discipline> Disciplines { get; set; } = new();
}

public class Discipline
{
    public string DisciplineName { get; set; }
}

public enum EducationLevel
{
    BACHELOR,
    MASTER,
    DOCTOR
}