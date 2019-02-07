using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUWPApp.Views.ViewModels
{
    public class ContainerVM : AbstractVM
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
                OnPropertyChanged("Home");
            }
        }

        public string Setting
        {
            get { return _setting; }
            set
            {
                _setting = value;
                OnPropertyChanged("Setting");
            }
        }

        public string Support
        {
            get { return _support; }
            set
            {
                _support = value;
                OnPropertyChanged("Support");
            }
        }

        public ContainerVM()
        {
            MainText = "UWP Application";
            Home = "Home";
            Setting = "Setting";
            Support = "Support";
        }
    }
}
