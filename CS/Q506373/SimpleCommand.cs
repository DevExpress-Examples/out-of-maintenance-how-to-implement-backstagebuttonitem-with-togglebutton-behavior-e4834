using System;
using System.Linq;
using System.Windows.Input;

namespace Q506373 {
    public class SimpleCommand : ICommand {
        public bool CanExecute(object parameter) {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter) {
            Console.WriteLine("SimpleCommand: Action!");
        }
    }
}
