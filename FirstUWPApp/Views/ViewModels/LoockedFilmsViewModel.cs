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
	public class LoockedFilmsViewModel : AbstractViewModel
	{
        private IFilmsService filmService;

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