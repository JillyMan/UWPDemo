using System.Collections.Generic;
using System.Windows.Input;
using FilmFindService.Interfaces;
using FilmFindService.Models;

namespace FirstUWPApp.Views.ViewModels
{
	public class LoockedFilmsViewModel : AbstractViewModel
	{
        private IFilmsService filmService;

        //TODO: after reload page need update films
        public IList<FilmInfoDTO> Films { get; private set; }

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