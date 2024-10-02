using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.ViewModels;

namespace Sinflex.Web.Controllers
{
    public class BookingController : Controller
	{
		private readonly IMovieService _movieService;
        private readonly ISaloonService _saloonService;

        public BookingController(IMovieService movieService, ISaloonService saloonService)
        {
            _movieService = movieService;
            _saloonService = saloonService;
        }

        public IActionResult Index(int movieId)
		{
			var movie = _movieService.GetMovieDetailsById(movieId);

			return View(movie);
		}
        public JsonResult GetSaloonByAirdate(DateTime airDate)
        {
            var saloons = _saloonService.GetSaloonByAirdate(airDate);
            // Saloon verilerini işleyin ve view'e gönderin


            //var deneme = new Dictionary<int, string>();

            //for (int i = 0; i < 3; i++)
            //{
            //    deneme.Add(i, $"Saloon{i}");
            //}


            return Json(saloons); // Örnek olarak JSON olarak geri döndürüyoruz
        }

        public JsonResult GetSessionsByAirdateSaloonId(int saloonid, DateTime airDate)
        {
            var result = _saloonService.GetSessionsByAirdateSaloonId(saloonid, airDate);


            return Json(result); 
        }

        public IActionResult Seating()
        {
            return View();
        }

        //[HttpGet]
        //public JsonResult GetNames()
        //{
        //    var names = new string[3]
        //    {
        //       "Ali",
        //       "Ahmet",
        //       "Hamza"

        //    };
        //    return new JsonResult(names);
        //}

        //[HttpPost]
        //public JsonResult SeedData()
        //{
        //  mySillyData mySillyData = new mySillyData()
        //  {
        //      ABC = 1,
        //      DEF = "ABCTEST",
        //  };
        //    return Json(mySillyData); 
        //}
    }
}
