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
        private INet net;
        private IRepository<FilmInfo> filmsCache;

        public string BaseUri { get; }

        public FindFilmService(INet net, IRepository<FilmInfo> filmsCache, string baseUri)
        {
            this.net = net;
            this.filmsCache = filmsCache;
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
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Film not found in storage: {filmName}");

                string newFilmName = string.Join("+", filmName.Split(' '));
                filmDAL = await net.GetObject<FilmInfo>(BaseUri + newFilmName);

                if (filmDAL != null)
                {
                    filmsCache.Insert(filmDAL);                    
                    filmDTO = createDTO(filmDAL); 
                }
                else
                {
                    LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Film not found in internet: {filmName}");
                }
            }
            else
            {
                //TODO: May be -> Refactor copy-past
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