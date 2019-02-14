using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmFindService;
using FilmFindService.Interfaces;
using FilmFindService.Models;
using FilmsDataAccessLayer.Models;
using Ninject;
using Windows.UI.Xaml.Media.Imaging;

namespace FirstUWPApp.Views.ViewModels
{
	public class HomeViewModel : AbstractViewModel
	{
        private IFilmsService filmService;

        private FilmInfoDTO filmInfo2;
        private FilmInfoDTO filmInfo;

        private string _imagesUri;
        public string Image
        {
            get
            {
                return _imagesUri;
            }
            set
            {
                _imagesUri = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private string _imagesUri2;
        public string Image2
        {
            get
            {
                return _imagesUri2;
            }
            set
            {
                _imagesUri2 = value;
                OnPropertyChanged(nameof(Image2));
            }
        }

        public HomeViewModel(IFilmsService service)
        {
            filmService = service;
            Init();
        }

        private async void Init()
        {
            filmInfo = await filmService.GetFilm("Logan");
            filmInfo2 = await filmService.GetFilm("Avatar");

            Image = filmInfo.Poster;
            Image2 = filmInfo2.Poster;
        }
    }
}