﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmFindService
{
    public class FilmInfo
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public DateTime Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Directors { get; set; }

        public string Plot { get; set; }
        public string Poster { get; set; }

        public string Type { get; set; }
    }
}