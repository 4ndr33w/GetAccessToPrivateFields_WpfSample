using GetAccessToPrivateFields_WpfSample.ViewModels;
using GetAccessToPrivateFields_WpfSample.Views;
using System.Windows;

namespace GetAccessToPrivateFields_WpfSample
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindowVM MainWindowVM = new MainWindowVM();

        public App() 
        {
            new MainWindow() { DataContext = MainWindowVM }.ShowDialog();
            Shutdown();
        }
    }
}
