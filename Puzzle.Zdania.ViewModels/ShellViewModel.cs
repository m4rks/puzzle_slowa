﻿using Puzzle.Zdania.Common4;
using Puzzle.Zdania.IServices;
using System;
using System.Windows.Input;

namespace Puzzle.Zdania.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;



        public RelayCommand<string> NavigateCommand { get; }


        public ICommand FireCommand { get; set; }

        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateCommand = new RelayCommand<string>(p => navigationService.Navigate(p));
            

        }


        private void Fire()
        {

        }

    }
}
