using ASPCoreFirstApp.Models;
using System.Collections.Generic;

namespace ASPCoreFirstApp.Services
{
    public interface IMoviesDataService
    {
        List<MovieModel> AllMovies();
        List<MovieModel> SearchTitles(string searchTitle);
        MovieModel GetTitleById(int movieId);
        int Insert(MovieModel title);
        bool Delete(MovieModel title);
        int Update(MovieModel title);
    }
}

