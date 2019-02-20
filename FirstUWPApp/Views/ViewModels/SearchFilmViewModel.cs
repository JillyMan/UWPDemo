using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmFindService.Interfaces;
using FilmFindService.Models;
using FirstUWPApp.Views.Commands;
using FirstUWPApp.Views.ViewModel.Locator;
using Windows.UI.Xaml;

namespace FirstUWPApp.Views.ViewModels
{
    public class SearchFilmViewModel : AbstractViewModel
    {
        public string RequiredFilm { get; set; }
        public TestCommand SearchFilm { get; }
        public IList<FilmInfoDTO> Films { get; private set; }

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
            Films = (await filmService.GetFilm(RequiredFilm))?.ToList();
           
            if(Films != null)
            {
                var loockedVM = (new ViewModelLocator().LookedFilmsViewModel);
                loockedVM.Load();
                OnPropertyChanged(nameof(Films));
            }
        }

        private bool CanFindFilm() => true;//!string.IsNullOrEmpty(RequiredFilm);
    }
}