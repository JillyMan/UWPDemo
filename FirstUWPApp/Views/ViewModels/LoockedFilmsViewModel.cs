using System.Collections.Generic;
using FilmFindService.Interfaces;
using FilmFindService.Models;

namespace FirstUWPApp.Views.ViewModels
{
	public class LoockedFilmsViewModel : AbstractViewModel
	{
        private IFilmsService filmService;

        public IList<FilmInfoDTO> Films { get; set; }
      
        public LoockedFilmsViewModel(IFilmsService service)
        {
            filmService = service;
            Init();
        }

        private async void Init()
        {           
            Films = new List<FilmInfoDTO>(await filmService.GetLookedFilms());
            OnPropertyChanged(nameof(Films));
        }
    }
}