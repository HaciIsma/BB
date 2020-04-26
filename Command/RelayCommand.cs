using System;
using System.Windows.Input;

namespace BakuBus.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<object> predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            this.action = action;
            this.predicate = predicate;

            if (action == null)
            {
                throw new Exception();
            }
        }

        public bool CanExecute(object parameter)
        {
            return predicate == null ? true : CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
