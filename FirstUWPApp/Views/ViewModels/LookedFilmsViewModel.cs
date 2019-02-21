using System.Collections.Generic;
using System.Threading.Tasks;
using FilmFindService.Interfaces;
using FilmFindService.Models;

namespace FirstUWPApp.Views.ViewModels
{
    public class LookedFilmsViewModel : AbstractViewModel
    {
        private IFilmsService filmService;

        private IList<FilmInfoDTO> films;
        public IList<FilmInfoDTO> LookedFilms
        {
            get
            {
                if(films == null)
                {
                    Load().ContinueWith((x) => { });
                }
                return films;
            }
        }
        
        public LookedFilmsViewModel(IFilmsService service)
        {
            filmService = service;
        }

        public async Task Load()
        {
            LogingService.LoggingServices.Instance.WriteLine<LookedFilmsViewModel>($"Try load film, current count {films?.Count}");
            films = new List<FilmInfoDTO>(await filmService.GetLookedFilms());
            LogingService.LoggingServices.Instance.WriteLine<LookedFilmsViewModel>($"Finish load film, current count {films?.Count}");
            OnPropertyChanged(nameof(LookedFilms));
        }
    }
}