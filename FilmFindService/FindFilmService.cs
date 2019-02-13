using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsDataAccessLayer.Models;
using FilmsDataAccessLayer;
using FilmFindService.Interfaces;
using FilmFindService.Util;
using FilmFindService.Networking;
using FilmFindService.Models;

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

        public async Task<FilmInfoDTO> GetFilm(string filmName)
        {
            if(filmName == null)
            {
                throw new ArgumentNullException();
            }

            FilmInfoDTO createDTO(FilmInfo x) => AutoMapper.Mapper.Map<FilmInfoDTO>(x);

            var filmDAL = (await filmsCache.Get())?
                    .Where(x => x.Title.PartialCompare(filmName))
                    .FirstOrDefault();

            FilmInfoDTO filmDTO = null;

            if (filmDAL == null && !string.IsNullOrEmpty(BaseUri))
            {
                string newFilmName = string.Join("+", filmName.Split(' '));
                filmDAL = await net.GetObject<FilmInfo>(BaseUri + newFilmName);

                if (filmDAL != null)
                {
                    filmsCache.Insert(filmDAL);
                    filmDTO = createDTO(filmDAL); 
                }
            }
            else
            {
                //TODO: Refactor copy-past
                filmDTO = createDTO(filmDAL);
            }

            return filmDTO;
        }

        public async Task<IEnumerable<FilmInfoDTO>> GetLookedFilms()
        {
            return AutoMapper.Mapper.Map<IEnumerable<FilmInfo>, List<FilmInfoDTO>>(await filmsCache.Get());
        }            
    }
}