using Puzzle.Zdania.Common4;
using Puzzle.Zdania.IServices;
using System;
using System.Windows.Input;
namespace Puzzle.Zdania.ViewModels
{
    public class ListOfTasksViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        public RelayCommand<string> NavigateCommand { get; }
        public ICommand PuzzlePageCommand { get; set; }

        public ListOfTasksViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            PuzzlePageCommand = new RelayCommand((x) => navigationService.Navigate("PuzzleZdaniaView", x));
            
            NavigateCommand = new RelayCommand<string>(p => navigationService.Navigate(p));
        }
    }
}
