using ASPCoreFirstApp.Models;
using Bogus;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Services
{
    

    public class SampleMovieRepository : IMoviesDataService
    {
        static List<MovieModel> movieList;
        public SampleMovieRepository()
        {
            movieList = new List<MovieModel>();

            for (int i = 0; i < 100; i++)
            {
                movieList.Add(new Faker<MovieModel>()
                    .RuleFor(p => p.MovieId, i)
                    .RuleFor(p => p.MovieTitle, f => f.Lorem.Slug())
                    .RuleFor(p => p.ReleaseDate, f => f.Date.Past())
                    );
            }
        }


        public List<MovieModel> AllMovies()
        {
            return movieList;
        }

        public bool Delete(MovieModel title)
        {
            throw new System.NotImplementedException();
        }

        public MovieModel GetTitleById(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(MovieModel title)
        {
            throw new System.NotImplementedException();
        }

        public List<MovieModel> SearchTitles(string searchTitle)
        {
            throw new System.NotImplementedException();
        }

        public int Update(MovieModel title)
        {
            throw new System.NotImplementedException();
        }
    }
}
