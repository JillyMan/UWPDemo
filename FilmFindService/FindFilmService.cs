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

        public async Task<IEnumerable<FilmInfoDTO>> GetFilm(string filmName)
        {
            if(string.IsNullOrEmpty(filmName))
            {
                return null;
            }

            //TODO: change find films
            var filmsDAL = (await filmsCache.Get())?
                    .Where(x => x.Title.PartialCompare(filmName));
                   
            IList<FilmInfoDTO> filmsDTO = null;

            if ((filmsDAL == null || filmsDAL.Count() == 0) && !string.IsNullOrEmpty(BaseUri))
            {
                LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Film not found in storage: {filmName}");

                string newFilmName = string.Join("+", filmName.Split(' '));
                var filmFromApi = await net.GetObject<FilmInfo>(BaseUri + newFilmName);

                if (filmFromApi != null)
                {
                    if(filmFromApi.Response)
                    {
                        await filmsCache.Insert(filmFromApi);
                        filmsDTO = new List<FilmInfoDTO>()
                        {
                            AutoMapper.Mapper.Map<FilmInfo, FilmInfoDTO>(filmFromApi)
                        };
                    }
                }
                else
                {
                    LogingService.LoggingServices.Instance.WriteLine<FilmRepository>($"Film not found in internet: {filmName}");
                }
            }
            else
            {
                //TODO: May be -> Refactor copy-past
                filmsDTO = AutoMapper.Mapper.Map<IEnumerable<FilmInfo>, List<FilmInfoDTO>>(filmsDAL);
            }

            return filmsDTO;
        }

        public async Task<IEnumerable<FilmInfoDTO>> GetLookedFilms()
        {
            LogingService.LoggingServices.Instance.WriteLine<FilmRepository>("GetLoockedFilms", MetroLog.LogLevel.Info);
            return AutoMapper.Mapper.Map<IEnumerable<FilmInfo>, List<FilmInfoDTO>>(await filmsCache.Get());
        }            
    }
}