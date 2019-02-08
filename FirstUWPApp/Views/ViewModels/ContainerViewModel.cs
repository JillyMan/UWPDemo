using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
    public class ContainerViewModel : AbstractViewModel
    {
        private string _home;
        private string _setting;
        private string _support;

        public string Home
        {
            get { return _home; }
            set
            {
                _home = value;
                OnPropertyChanged(nameof(Home));
            }
        }

        public string Setting
        {
            get { return _setting; }
            set
            {
                _setting = value;
                OnPropertyChanged(nameof(Setting));
            }
        }

        public string Support
        {
            get { return _support; }
            set
            {
                _support = value;
                OnPropertyChanged(nameof(Support));
            }
        }

        public ContainerViewModel()
        {
            Home = "Home";
            Setting = "Setting";
            Support = "Support";
        }
    }
}
