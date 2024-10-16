using Sinflex.BLL.Repositories.ViewModels.SeatingViewModels;
using Sinflex.BLL.Repositories.ViewModels.TicketViewModels;

namespace Sinflex.BLL.Repositories.Abstracts
{
    public interface ITicketService
    {
        Task<TicketViewModel> GenerateTicket(SeatingViewModel seatingViewModel);
    }
}
