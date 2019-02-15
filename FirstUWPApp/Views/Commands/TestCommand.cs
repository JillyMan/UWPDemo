using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace FirstUWPApp.Views.Commands
{
    public class TestCommand : ICommand
    {
        private readonly Action execute = async () => { var dialog = new MessageDialog("Hello"); await dialog.ShowAsync(); };
        private readonly Func<bool> canExecute;
        public event EventHandler CanExecuteChanged;

        public TestCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute();
        
        public void Execute(object parameter) => execute?.Invoke();

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}