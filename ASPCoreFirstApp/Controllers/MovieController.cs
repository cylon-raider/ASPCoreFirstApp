using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreFirstApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            SampleMovieRepository repository = new SampleMovieRepository();
            return View(repository.AllMovies());
        }
    }
}
