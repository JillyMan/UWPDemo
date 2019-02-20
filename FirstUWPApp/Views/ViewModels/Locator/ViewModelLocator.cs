using Ninject;
using FirstUWPApp.AppConfig.NinjectModules;
using FirstUWPApp.Views.ViewModels;

namespace FirstUWPApp.Views.ViewModel.Locator
{
    public class ViewModelLocator
    {
        private static IKernel kernel = new StandardKernel(new FilmServiceModule());

        public ViewModelLocator() { }

        public LookedFilmsViewModel LookedFilmsViewModel
        {
            get { return kernel.Get<LookedFilmsViewModel>(); }
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