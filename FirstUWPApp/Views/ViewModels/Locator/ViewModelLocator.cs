using Ninject;
using FirstUWPApp.AppConfig.NinjectModules;
using FirstUWPApp.Views.ViewModels;

namespace FirstUWPApp.Views.ViewModel.Locator
{
    public class ViewModelLocator
    {
        private IKernel kernel;

        public ViewModelLocator()
        {
            kernel = new StandardKernel(new FilmServiceModule());
        }

        public HomeViewModel HomeViewModel
		{
            get
            {
                var obj = kernel.Get<HomeViewModel>();
                return obj;
            }
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
