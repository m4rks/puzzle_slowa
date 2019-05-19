using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Puzzle.Zdania.IServices
{
    public interface IDialogFacade
    {
        object ShowDialogYesNo(string message);
        void ShowDialogYesNo2(object vm);
    }
}
