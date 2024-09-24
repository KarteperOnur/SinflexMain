using Microsoft.EntityFrameworkCore;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.BLL.Repositories.ViewModels.MovieViewModels;
using Sinflex.DAL.Context;
using Sinflex.Model.Entities;

namespace Sinflex.BLL.Repositories.Concretes
{
	public class MovieService : IMovieService
	{

		public readonly IRepository<Movie> _movieRepository;
		public readonly IRepository<Session> _sessionRepository;
		public readonly IRepository<AirDate> _airDateRepository;
		public readonly IRepository<Saloon> _saloonRepository;

		public MovieService(IRepository<Movie> movieRepository, IRepository<Session> sessionRepository, IRepository<AirDate> airDateRepository, IRepository<Saloon> saloonRepository)
		{
			_movieRepository = movieRepository;
			_sessionRepository = sessionRepository;
			_airDateRepository = airDateRepository;
			_saloonRepository = saloonRepository;
		}

		public IEnumerable<MovieListModel> GetAllMovies()
		{
			//IRepository Queryable Get yapılmalı. 
			var movies = _movieRepository.GetAllQ()
				.Include(p => p.Sessions)
				.Include(p => p.AirDates)//Include Tablo'nun alt tablolarındaki veriyi de getirir.
				.ToList();

			var movieList = movies.Select(x => new MovieListModel
			{
				Name = x.Name,
				Duration = x.Duration,
				ReleaseDate = x.ReleaseDate,
				AirDates = x.AirDates.Select(p => p.Airdate).ToList(),
				Actors = x.Actors,
				AgeRestriction = x.AgeRestriction,
				Director = x.Director,
				Genre = x.Genre,
				Id = x.Id,


			}).ToList();

			return movieList;
		}

		public IEnumerable<MovieListModel> GetByDate(DateTime searchDate)
		{
			var movies = _movieRepository
				.GetAllQ()
				.Include(p => p.AirDates)
				.Where(m => m.AirDates.Any(x => x.Airdate == searchDate));

			return movies.Select(m => new MovieListModel
			{
				Name = m.Name,
				Duration = m.Duration,
				ReleaseDate = m.ReleaseDate,
				AirDates = m.AirDates.Select(p => p.Airdate).ToList(),
				Actors = m.Actors,
				AgeRestriction = m.AgeRestriction,
				Director = m.Director,
				Genre = m.Genre,
				Id = m.Id,
			}).ToList();
		}

		public MovieDetailsBookingViewModel GetMovieDetailsById(int movieId)
		{
			//İSTEDİĞİM MOVİE NESNESİ ---BAŞLANGIÇ---
			var movie = _movieRepository.GetbyId(movieId);

			var sessions = _sessionRepository
				.GetAllQ()
				.Include(p => p.Movies)
				.Where(x => x.Movies.Id == movie.Id)
				.ToList();

			// airDates
			var airDates = _airDateRepository
				.GetAllQ()
				.Where(x => x.Movie.Id == movie.Id)
				.ToList();

			// saloon

			var saloons = _saloonRepository
				.GetAllQ()
				.Include(p => p.Movies)
				.Where(c => c.Movies.Any(x => x.Id == movie.Id))
				.ToList();

			movie.AirDates = airDates;
			movie.Saloons = saloons;
			movie.Sessions = sessions;
			//İSTEDİĞİM MOVİE NESNESİ ---BİTİŞ---

            var result = new MovieDetailsBookingViewModel
			{
				Airdates = movie.AirDates.Select(x => x.Airdate).ToList(),
				Saloons = movie.Saloons.ToDictionary(x => x.Id, k => k.Name),
                Sessions = movie.Sessions.Select(x => x.Time).ToList(),
				Name = movie.Name,
				ImagePath = movie.ImagePath,
			};

			return result;
		}
	}
}
