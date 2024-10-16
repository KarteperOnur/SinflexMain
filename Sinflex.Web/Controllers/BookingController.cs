using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.BLL.Repositories.ViewModels.SeatingViewModels;
using Sinflex.Model.Entities;


namespace Sinflex.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;
        private readonly ISaloonService _saloonService;
        private readonly ISeatService _seatService;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(IMovieService movieService, ISaloonService saloonService, ISeatService seatService, ITicketService ticketService, UserManager<AppUser> userManager)
        {
            _movieService = movieService;
            _saloonService = saloonService;
            _seatService = seatService;
            _ticketService = ticketService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index(int movieId)
        {
                var movie = _movieService.GetMovieDetailsById(movieId);

                return View(movie);
        }

        public JsonResult GetSaloonByAirdate(DateTime airDate)
        {
            var saloons = _saloonService.GetSaloonByAirdate(airDate);

            return Json(saloons);
        }

        public JsonResult GetSessionsByAirdateSaloonId(int saloonid, DateTime airDate)
        {
            var result = _saloonService.GetSessionsByAirdateSaloonId(saloonid, airDate);


            return Json(result);
        }



        [HttpPost]
        public IActionResult Seating(MovieDetailsPostViewModel model)
       {
            //_saloonService.SetPrice()
            //SERVİSTE DOLDUR
            //if (await _userManager.GetUserAsync().Result.UserType == UserType.VIP)
            //    model.PurchasePrice = 75;

            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> SubmitSeatingData([FromBody] SeatingViewModel model)
        {
            
            var insertSeatResult = await _seatService.InsertSeat(model);
            
            if (insertSeatResult == true)
            {
                var ticketViewModel = await _ticketService.GenerateTicket(model);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Ticket", ticketViewModel) });
            }
            else
            {
                return Json(new { success = false, message = "Error" });
            }
        }

    }
}
