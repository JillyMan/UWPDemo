using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmFindService;
using Windows.UI.Xaml.Media.Imaging;

namespace FirstUWPApp.Views.ViewModels
{
	public class HomeViewModel : AbstractViewModel
	{
        private FindFilmService ffs = new FindFilmService("http://www.omdbapi.com/");
        private FilmInfo filmInfo;

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

		public HomeViewModel()
        {
            Init();
        }

        private async void Init()
        {
            filmInfo = await ffs.GetFilms("Avengers Infinity War");
            Image = filmInfo.Poster;
        }
    }
}