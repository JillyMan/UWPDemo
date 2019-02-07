using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
    public class AbstractVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected string _mainText;
        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                OnPropertyChanged("MainText");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
