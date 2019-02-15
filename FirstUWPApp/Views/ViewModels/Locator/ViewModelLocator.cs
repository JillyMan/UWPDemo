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

        public LoockedFilmsViewModel LoockedFilmsViewModel
        {
            get { return kernel.Get<LoockedFilmsViewModel>(); }
        }

        public FilmInfoViewModel FilmInfoViewModel
        {
            get { return kernel.Get<FilmInfoViewModel>(); }
        }

        public SearchFilmViewModel SearchFilmViewModel
        {
            get { return kernel.Get<SearchFilmViewModel>(); }
        }

        public ContainerViewModel ContainerViewModel
        {
            get { return kernel.Get<ContainerViewModel>(); }
        }
    }
}