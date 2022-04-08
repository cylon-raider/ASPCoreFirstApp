using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreFirstApp.Models
{
    public class MovieModel
    {

        [DisplayName("Movie ID Number")]
        public int MovieId { get; set; }

        [DisplayName("Movie Title")]
        public string MovieTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Movie Release Date")]
        public DateTime ReleaseDate { get; set; }

        public MovieModel(int movieId, string title, DateTime releaseDate)
        {
            MovieId = movieId;
            MovieTitle = title;
            this.ReleaseDate = releaseDate;
        }

        public MovieModel()
        { }
    }
}
