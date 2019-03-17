using Puzzle.Zdania.IServices;
using Puzzle.Zdania.ViewModels;
using Puzzle.Zdania.WPFClient.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Puzzle.Zdania.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            INavigationService navigationService = new FrameNavigationService();
            //navigationService.Navigate("")
            //     navigationService.Navigate("DepartmentsView");
            ShellView app = new ShellView();
            ShellViewModel context = new ShellViewModel(navigationService);
            app.DataContext = context;
            app.Show();
            navigationService.Navigate("ListOfTasksView");//ListOfTasksView
        }
    }
}
