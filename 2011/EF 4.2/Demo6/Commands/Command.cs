using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Dajbych.Demo6.Commands {
    public class Command<T> : ICommand where T : class {
        private Action<T> execute;
        private Func<T, bool> enabled;

        public Command(Action<T> execute, Func<T, bool> enabled = null) {
            this.execute = execute;
            this.enabled = enabled;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            if (enabled == null) {
                return true;
            } else {
                return enabled.Invoke(parameter as T);
            }
        }

        public void Execute(object parameter) {
            execute.Invoke(parameter as T);
        }
    }
}