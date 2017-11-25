using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication.ViewModel
{
    public class Command : ICommand
    {
        private Action<object> ExecuteDelegate { get; set; }
        private Func<object, bool> CanExecuteDelegate { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.ExecuteDelegate = execute;
            this.CanExecuteDelegate = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.CanExecuteDelegate == null || this.CanExecuteDelegate(parameter);
        }

        public void Execute(object parameter)
        {
            this.ExecuteDelegate(parameter);
        }
    }
}
