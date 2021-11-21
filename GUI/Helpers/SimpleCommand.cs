using System;
using System.Windows.Input;

namespace GUI.Helpers
{
    public class SimpleCommand : SimpleCommand<object>
    {
        public SimpleCommand(Action<object> action) : base(action)
        {
        }
    }

    public class SimpleCommand<T> : ICommand where T : class
    {
        private readonly Action<T> _action;

        public SimpleCommand(Action<T> action)
        {
            _action = action;
            CanExecuteChanged = (sender, args) => { };
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}