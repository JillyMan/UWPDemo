using System.Collections.Generic;
using FilmFindService.Interfaces;
using FilmFindService.Models;

namespace FirstUWPApp.Views.ViewModels
{
    public class LookedFilmsViewModel : AbstractViewModel
    {
        private IFilmsService filmService;

        private IList<FilmInfoDTO> films;
        public IList<FilmInfoDTO> Films
        {
            get
            {
                if(films == null)
                {
                    Load();
                }
                return films;
            }
        }
        
        public LookedFilmsViewModel(IFilmsService service)
        {
            filmService = service;
        }

        public async void Load()
        {
            LogingService.LoggingServices.Instance.WriteLine<LookedFilmsViewModel>($"Try load film, current count {films?.Count}");
            films = new List<FilmInfoDTO>(await filmService.GetLookedFilms());
            LogingService.LoggingServices.Instance.WriteLine<LookedFilmsViewModel>($"Finish load film, current count {films?.Count}");
            OnPropertyChanged(nameof(Films));
        }
    }
}