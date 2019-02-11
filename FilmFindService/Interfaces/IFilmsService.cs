using System.Collections.Generic;
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
