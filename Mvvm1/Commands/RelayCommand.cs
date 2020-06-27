using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm1.Commands
{
    public class RelayCommand : ICommand
    {
        Action Dowork;

        public RelayCommand(Action doWork)
        {
            Dowork = doWork;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Dowork();
        }
    }
}
