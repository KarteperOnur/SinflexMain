using Sinflex.BLL.Repositories.ViewModels.BookingSaloonViewModels;

namespace Sinflex.BLL.Repositories.Abstracts
{
    public interface ISaloonService
    {
        BookingSaloonViewModel GetSaloonByAirdate(DateTime airDate);
        BookingSaloonViewModel GetSessionsByAirdateSaloonId(int saloonid, DateTime airDate);
    }
}
