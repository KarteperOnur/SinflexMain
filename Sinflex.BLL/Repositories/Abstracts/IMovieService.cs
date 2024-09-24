using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.BLL.Repositories.ViewModels.MovieViewModels;
using Sinflex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.Abstracts
{
    public interface IMovieService
    {
        IEnumerable<MovieListModel> GetAllMovies();
		IEnumerable<MovieListModel> GetByDate(DateTime searchDate);
        MovieDetailsBookingViewModel GetMovieDetailsById(int movieId);
	}
}
