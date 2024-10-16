using Sinflex.BLL.Repositories.ViewModels.SeatingViewModels;

namespace Sinflex.BLL.Repositories.Abstracts
{
    public interface ISeatService
    {
        Task<bool> InsertSeat(SeatingViewModel seatingViewModel);
    }
}
