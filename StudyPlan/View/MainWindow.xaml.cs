using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyPlan.Model;
using StudyPlan.ViewModel;

namespace StudyPlan;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowVM();
        MessageBox.Show("hello");
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainWindowVM;

        if (vm?.SelectedPlan != null && !string.IsNullOrEmpty(Input.Text))
        {
            vm.SelectedPlan.Disciplines.Add(new Discipline
            {
                DisciplineName = Input.Text.Trim()
            });
            MessageBox.Show("Added successfully");
            Input.Clear();
        }
    }
}