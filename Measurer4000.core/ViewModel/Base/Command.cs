using System;
using System.Windows.Input;

namespace Measurer4000.Core.ViewModel.Base
{
    public class Command : ICommand
    {
        private readonly Action _actionToExecute;

        public Command(Action action)
        {
            _actionToExecute = action;                
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _actionToExecute?.Invoke();
        }
    }

    public class Command<T> : ICommand
    {        
        private readonly Action<T> _actionToExecute;

        public Command(Action<T> action)
        {
            _actionToExecute = action;
        }

            
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (typeof(T) == parameter.GetType())
                throw new ArgumentException("Incorrectly type passed");

            _actionToExecute?.Invoke((T)parameter);
        }
    }
}
