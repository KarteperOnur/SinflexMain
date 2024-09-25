using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.Model.Entities;

namespace Sinflex.Web.Controllers
{
	public class BookingController : Controller
	{
		private readonly IMovieService _movieService;

		public BookingController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		public IActionResult Index(int movieId)
		{
			var movie = _movieService.GetMovieDetailsById(movieId);

			return View(movie);
		}


        [HttpGet]
        public JsonResult GetNames()
        {
            var names = new string[3]
            {
               "Ali",
               "Ahmet",
               "Hamza"

            };
            return new JsonResult(names);
        }

        [HttpPost]
        public JsonResult PostName(string name)
        {
            return new JsonResult(Ok());

        }
    }
}
