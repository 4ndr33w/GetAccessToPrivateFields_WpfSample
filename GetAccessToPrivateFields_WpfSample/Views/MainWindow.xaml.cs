using GetAccessToPrivateFields_WpfSample.ViewModels;
using System.Windows;

namespace GetAccessToPrivateFields_WpfSample.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }
    }
}
