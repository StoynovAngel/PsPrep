using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using StudyPlan.Model;

namespace StudyPlan.ViewModel;

public class MainWindowVM : INotifyPropertyChanged
{
    public ObservableCollection<Plan> Plans { get; set; }

    private Plan _selectedPlan;

    public Plan SelectedPlan
    {
        get => _selectedPlan;
        set
        {
            _selectedPlan = value;
            OnPropertyChanged(nameof(SelectedPlan));
        }
    }

    public MainWindowVM()
    {
        using var context = new StudyPlanContext();
        var plans = Plans =
        [
            new Plan
            {
                Name = "KSI",
                EducationLevel = EducationLevel.BACHELOR,
                YearsOfEducation = 4,
                Disciplines =
                [
                    new Discipline
                    {
                        DisciplineName = "Mathematics"
                    },
                    new Discipline
                    {
                        DisciplineName = "PE"
                    },
                    new Discipline
                    {
                        DisciplineName = "PS"
                    },
                    new Discipline
                    {
                        DisciplineName = "PPE"
                    }
                ]
            }
        ];
        foreach (var plan in plans)
        {
            CheckForDisciplineSize(plan);
        }
    }

    private void CheckForDisciplineSize(Plan plan)
    {
        if (plan.Disciplines.Count > 10)
        {
            MessageBox.Show("You cannot have more than 10 disciplines");
        } 
    }

    private Plan FilterDisciplinesByName(Plan plan, string filteredString)
    {
        ObservableCollection<Discipline> filteredDisciplines =
            (ObservableCollection<Discipline>) from discipline in plan.Disciplines
            where discipline.DisciplineName.Equals(filteredString)
            select discipline;
        return new Plan
        {
            Name = plan.Name,
            EducationLevel = plan.EducationLevel,
            YearsOfEducation = plan.YearsOfEducation,
            Disciplines = filteredDisciplines
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}