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
using WpfAppPractise.ViewModel;

namespace WpfAppPractise;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowVM();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        string toDoText = ToDoInput.Text;
        if (!string.IsNullOrEmpty(toDoText))
        {
            TextBlock textBlock = new TextBlock
            {
                Text = toDoText
            };
            ToDoList.Children.Add(textBlock);
            ToDoInput.Clear();
        }
    }
}