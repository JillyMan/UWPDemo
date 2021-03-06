﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FilmFindService.Models;

namespace FilmFindService.Interfaces
{
    public interface IFilmsService
    {
        Task<IEnumerable<FilmInfoDTO>> GetLookedFilms();
        Task<IEnumerable<FilmInfoDTO>> GetFilm(string filmName);
    }
}
