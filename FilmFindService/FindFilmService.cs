using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDataAccessLayer.Models;
using FilmsDataAccessLayer;
using FilmFindService.Interfaces;
using FilmsDataAccessLayer.Networking;

using FilmFindService.Util;

namespace FilmFindService
{ 
    public class FindFilmService : IFilmsService
    {

        private string BaseUri { get; set; }

        private INet net = new NetHttp();
        private IRepository<FilmInfo> filmsCache = new FilmRepository("StorageFilms.txt");

        public FindFilmService(string baseUri)
        {
            BaseUri = baseUri;
        }

        public async Task<FilmInfo> GetFilm(string filmName)
        {
            if(filmName == null)
            {
                throw new ArgumentNullException();
            }

            FilmInfo film = (await filmsCache.Get())?
                    .Where(x => x.Title.PartialCompare(filmName))
                    .FirstOrDefault();
            
            if (film == null)
            {
                if (string.IsNullOrEmpty(BaseUri))
                {
                    throw new ArgumentNullException("Invalid: " + nameof(BaseUri));
                }

                string newFilmName = string.Join("+", filmName.Split(' '));
                film = await net.GetObject<FilmInfo>(BaseUri + newFilmName);

                if (film != null)
                {
                    filmsCache.Insert(film);
                }
            }
            return film;
        }

        public async Task<IEnumerable<FilmInfo>> GetLookedFilms()
        {
            return await filmsCache.Get();
        }
    }
}