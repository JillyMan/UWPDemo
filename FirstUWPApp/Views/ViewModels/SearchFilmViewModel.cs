using System.Collections.Generic;
using System.Linq;
using FilmFindService.Interfaces;
using FilmFindService.Models;
using FirstUWPApp.Views.Commands;
using FirstUWPApp.Views.ViewModel.Locator;

namespace FirstUWPApp.Views.ViewModels
{
    public class SearchFilmViewModel : AbstractViewModel
    {
        public string RequiredFilm { get; set; }
        public TestCommand SearchFilm { get; }
        public IList<FilmInfoDTO> FoundFilms { get; private set; }

        private readonly IFilmsService filmService;

        public SearchFilmViewModel(IFilmsService service)
        {
            filmService = service;

            SearchFilm = new TestCommand(
                FindFilm,
                CanFindFilm);
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

        private bool CanFindFilm() => true;//!string.IsNullOrEmpty(RequiredFilm);
    }
}