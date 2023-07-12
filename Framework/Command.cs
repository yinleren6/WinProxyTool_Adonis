using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinProxyTool_Adonis.Franework

{
    abstract class Command : ICommand
    {
        public abstract void Execute(object parameter);
        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
         
    }
}
