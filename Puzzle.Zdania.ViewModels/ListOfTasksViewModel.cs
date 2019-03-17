using Puzzle.Zdania.Common4;
using Puzzle.Zdania.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Zdania.ViewModels
{
    public class ListOfTasksViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        public RelayCommand<string> NavigateCommand { get; }

        public ListOfTasksViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateCommand = new RelayCommand<string>(p => navigationService.Navigate(p));


        }
    }
}
