using System.Collections.Generic;
using FilmFindService.Interfaces;
using FilmFindService.Models;

namespace FirstUWPApp.Views.ViewModels
{
    //TODO: amm, check this moment letter again
    public class LoockedFilmsViewModel : AbstractViewModel
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
        
        public LoockedFilmsViewModel(IFilmsService service)
        {
            filmService = service;
        }

        public async void Load()
        {           
            films = new List<FilmInfoDTO>(await filmService.GetLookedFilms());
            OnPropertyChanged(nameof(Films));
        }
    }
}