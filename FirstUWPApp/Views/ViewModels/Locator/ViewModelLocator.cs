using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstUWPApp.Views.ViewModels;

namespace FirstUWPApp.Views.ViewModel.Locator
{
    public class ViewModelLocator
    {
        public HomeVM HomeVM
        {
            get { return new HomeVM(); }
        }

        public ContainerVM ContainerVM
        {
            get { return new ContainerVM(); }
        }

        public SupportVM SupportVM
        {
            get { return new SupportVM(); }
        }

        public SettingVM SettingVM
        {
            get { return new SettingVM(); }
        }
    }
}
