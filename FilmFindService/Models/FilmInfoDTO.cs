namespace FilmFindService.Models
{
    public class FilmInfoDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }

        public string Released { get; set; }

        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Directors { get; set; }

        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

        public string ImdRating { get; set; }
        public string ImdbVotes { get; set; }

        public string Type { get; set; }
        public string Production { get; set; }
    }
}
