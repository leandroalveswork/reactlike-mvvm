using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReactlikeMvvm.HiCustomCommand
{
    public class HiCommandComParam<T> : ICommand
    {
        private Action<T>? _fnCommand;
        private Func<T, Task>? _fnCommandAsync;
        public bool EAsync => _fnCommand is null;
        public HiCommandComParam(Action<T> fnCommand)
        {
            _fnCommand = fnCommand;
        }
        public HiCommandComParam(Func<T, Task> fnCommandAsync)
        {
            _fnCommandAsync = fnCommandAsync;
        }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException();
            }
            if (!parameter.GetType().IsAssignableTo(typeof(T)))
            {
                throw new ArgumentException("CommandParameter possui um tipo incorreto.");
            }
            var parameterAsT = (T)parameter;
            if (!EAsync)
            {
                _fnCommand?.Invoke(parameterAsT);
            }
            else
            {
                _fnCommandAsync?.Invoke(parameterAsT).Wait();
            }
        }
    }
}