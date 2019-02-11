using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDataAccessLayer.Models;

namespace FilmFindService.Interfaces
{
    public interface IFilmsService
    {
        Task<IEnumerable<FilmInfo>> GetLookedFilms();
        Task<FilmInfo> GetFilm(string filmName);
    }
}
