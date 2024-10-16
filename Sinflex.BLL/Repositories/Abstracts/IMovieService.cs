using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.BLL.Repositories.ViewModels.MovieViewModels;

namespace Sinflex.BLL.Repositories.Abstracts
{
    public interface IMovieService
    {
        IEnumerable<MovieListModel> GetAllMovies(string searchFilter, bool isSecondClick);
		IEnumerable<MovieListModel> GetByDate(DateTime searchDate);
        MovieDetailsBookingViewModel GetMovieDetailsById(int movieId);
	}
}
