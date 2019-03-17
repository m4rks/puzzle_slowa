using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.Zdania.IServices
{
    public interface INavigationService
    {
        void Navigate(string viewname, object parameter = null);
        void GoForward();
        void GoBack();

        object Parameter { get; }
    }
}
