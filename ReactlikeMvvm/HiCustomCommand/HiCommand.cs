using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReactlikeMvvm.HiCustomCommand
{
    public class HiCommand : ICommand
    {
        private Action? _fnCommand;
        private Func<Task>? _fnCommandAsync;
        public bool EAsync => _fnCommand is null;
        public HiCommand(Action fnCommand)
        {
            _fnCommand = fnCommand;
        }
        public HiCommand(Func<Task> fnCommandAsync)
        {
            _fnCommandAsync = fnCommandAsync;
        }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (!EAsync)
            {
                _fnCommand?.Invoke();
            }
            else
            {
                _fnCommandAsync?.Invoke().Wait();
            }
        }
    }
}