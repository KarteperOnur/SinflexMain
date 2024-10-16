using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.Abstracts;

namespace Sinflex.Web.Controllers
{
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

    }
}
