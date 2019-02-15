using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmFindService.Interfaces;
using FilmFindService.Models;
using FirstUWPApp.Views.Commands;

namespace FirstUWPApp.Views.ViewModels
{
    public class SearchFilmViewModel : AbstractViewModel
    {
        public string RequiredFilm { get; set; }
        public TestCommand Test { get; }
        public FilmInfoDTO FilmInfo { get; private set; }

        private string _posterUri;
        public string Poster
        {
            get
            {
                return _posterUri;
            }
            set
            {
                _posterUri = value;
                OnPropertyChanged(nameof(Poster));
            }
        }

        private readonly IFilmsService filmService;

        public SearchFilmViewModel(IFilmsService service)
        {
            filmService = service;

            Test = new TestCommand(
                FindFilm,
                CanFindFilm);
        }

        private async void FindFilm()
        {
            FilmInfo = await filmService.GetFilm(RequiredFilm);
            Poster = FilmInfo == null ? "": FilmInfo.Poster;
        }

        private bool CanFindFilm() => true;//!string.IsNullOrEmpty(RequiredFilm);
    }
}