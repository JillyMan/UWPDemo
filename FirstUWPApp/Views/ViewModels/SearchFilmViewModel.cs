using System.Linq;
using FilmFindService.Models;
using System.Collections.Generic;
using FilmFindService.Interfaces;
using FirstUWPApp.Views.Commands;
using FirstUWPApp.Views.ViewModel.Locator;

namespace FirstUWPApp.Views.ViewModels
{
    public class SearchFilmViewModel : AbstractViewModel
    {
        public string RequiredFilm { get; set; }
        public RelayCommand SearchFilm { get; }
        public IList<FilmInfoDTO> FoundFilms { get; private set; }

        private readonly IFilmsService filmService;

        public SearchFilmViewModel(IFilmsService service)
        {
            filmService = service;

            SearchFilm = new RelayCommand(FindFilm);
        }

        private async void FindFilm()
        {
            FoundFilms = (await filmService.GetFilm(RequiredFilm))?.ToList();
                       
            if(FoundFilms != null)
            {
                var loockedVM = (new ViewModelLocator().LookedFilmsViewModel);
                await loockedVM.Load();
                OnPropertyChanged(nameof(FoundFilms));
            }
        }
    }
}