using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.ViewModels.TicketViewModels;

namespace Sinflex.Web.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index(TicketViewModel model)
        {
            return View(model);
        }
    }
}
