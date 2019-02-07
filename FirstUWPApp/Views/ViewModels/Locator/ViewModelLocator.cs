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
        public HomeViewModel HomeViewModel
		{
            get { return new HomeViewModel(); }
        }

        public ContainerViewModel ContainerViewModel
		{
            get { return new ContainerViewModel(); }
        }

        public SupportViewModel SupportViewModel
		{
            get { return new SupportViewModel(); }
        }

        public SettingViewModel SettingViewModel
		{
            get { return new SettingViewModel(); }
        }
    }
}
