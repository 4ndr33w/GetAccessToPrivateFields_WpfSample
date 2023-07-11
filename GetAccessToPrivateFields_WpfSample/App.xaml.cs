using GetAccessToPrivateFields_WpfSample.ViewModels;
using GetAccessToPrivateFields_WpfSample.Views;
using GetAccessToPrivateFields_WpfSample.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GetAccessToPrivateFields_WpfSample
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindowVM MainWindowVM;

        public App() 
        {
            new MainWindow() { DataContext = MainWindowVM }.ShowDialog();
            Shutdown();
        }
    }
}
