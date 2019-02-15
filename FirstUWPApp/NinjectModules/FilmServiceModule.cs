using FilmFindService;
using FilmFindService.Interfaces;
using FilmFindService.Networking;
using FilmsDataAccessLayer;
using FilmsDataAccessLayer.Models;
using FirstUWPApp.Views.ViewModels;
using Ninject;
using Ninject.Modules;

namespace FirstUWPApp.AppConfig.NinjectModules
{
    public class FilmServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INet>().To<NetHttp>();

            Bind<IRepository<FilmInfo>>()
                .To<FilmRepository>()
                .WithConstructorArgument("StorageFilms.txt");

            Bind<IFilmsService>()
                .To<FindFilmService>()
                .WithConstructorArgument("http://www.omdbapi.com/?plot=full&apikey=b5a32870&t=");

            Bind<LoockedFilmsViewModel>()
               .ToSelf()
               .InSingletonScope();

            Bind<FilmInfoViewModel>()
                .ToSelf()
                .InSingletonScope();

            Bind<SearchFilmPage>()
               .ToSelf()
               .InSingletonScope();

            Bind<ContainerViewModel>()
               .ToSelf()
               .InSingletonScope();
        }
    }
}