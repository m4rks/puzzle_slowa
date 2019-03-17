using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Puzzle.Zdania.Common4
{
    public class RelayCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        // private readonly Predicate<object> canExecute2;


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke(parameter);

            //if (canExecute!=null)
            //{
            //    return canExecute.Invoke(parameter);
            //}
            //else
            //{
            //    return true;
            //}
        }

        public void Execute(object parameter)
        {
            //if (execute!=null)
            //    execute.Invoke(parameter);

            execute?.Invoke(parameter);
        }
    }

    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter) => execute?.Invoke((T)parameter);
    }
}
