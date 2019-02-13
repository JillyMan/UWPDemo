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
using Windows.UI.Xaml.Media.Imaging;

namespace FirstUWPApp.Views.ViewModels
{
	public class HomeViewModel : AbstractViewModel
	{
        //TODO: hard code of link, not cool :(
        private IFilmsService ffs = new FindFilmService("http://www.omdbapi.com/?plot=full&apikey=b5a32870&t=");
        private FilmInfoDTO filmInfo2;
        private FilmInfoDTO filmInfo;

        public IList<string> UriImages = new List<string>();

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

        public HomeViewModel()
        {
            Init();
        }

        private async void Init()
        {
            filmInfo = await ffs.GetFilm("Logan");
            filmInfo2 = await ffs.GetFilm("Avatar");

            Image = filmInfo.Poster;
            Image2 = filmInfo2.Poster;

            //UriImages.Add(filmInfo.Poster);
            //UriImages.Add(filmInfo2.Poster);
        }
    }
}