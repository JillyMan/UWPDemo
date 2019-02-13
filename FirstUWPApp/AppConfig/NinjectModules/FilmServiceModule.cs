using FilmFindService;
using FilmFindService.Interfaces;
using FilmFindService.Networking;
using FilmsDataAccessLayer;
using FilmsDataAccessLayer.Models;
using Ninject;
using Ninject.Modules;

namespace FirstUWPApp.AppConfig.NinjectModules
{
    public class FilmServiceModule : NinjectModule
    {
        public override void Load()
        {
            /*TODO: 
             * Hard code string, DON'T forgot !!!!
             * and specify name args BAD!.           
             */
            Bind<INet>().To<NetHttp>();

            Bind<IRepository<FilmInfo>>()
                .To<FilmRepository>()
                .WithConstructorArgument("StorageFilms.txt");

            Kernel.Bind<IFilmsService>()
                .To<FindFilmService>()
                .WithConstructorArgument("baseUri", "http://www.omdbapi.com/?plot=full&apikey=b5a32870&t=")
                .WithConstructorArgument("net", Kernel.Get<INet>())
                .WithConstructorArgument("filmsCache", Kernel.Get<FilmRepository>());
        }
    }
}