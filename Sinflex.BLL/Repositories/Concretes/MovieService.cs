using Microsoft.EntityFrameworkCore;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.BLL.Repositories.ViewModels.MovieViewModels;
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
                .Include(p => p.Categories)
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
                Category = string.Join(',', x.Categories.Select(p => p.Description).ToList()),
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
                Category = string.Join(',', m.Categories.Select(p => p.Description).ToList()),
                Id = m.Id,
            }).ToList();
        }

        public MovieDetailsBookingViewModel GetMovieDetailsById(int movieId)
        {
            //İSTEDİĞİM MOVİE NESNESİ ---BAŞLANGIÇ---
            var movie = _movieRepository.GetbyId(movieId);

            // airDates
            var airDates = _airDateRepository
                .GetAllQ()
                .Where(x => x.Movie.Id == movie.Id)
                .ToList();

            var saloons = _saloonRepository
                .GetAllQ()
                .Include(p => p.Movies)
                .Where(c => c.Movies.Any(x => x.Id == movie.Id))
                .ToList();

            var sessions = _sessionRepository
                .GetAllQ()
                .Include(p => p.Movies)
                .Where(x => x.Movies.Id == movie.Id)
                .ToList();

            //var search = "Ton";
            //List<string> aListesi = new List<string>() { "sadasd", "adasda", "Tonay", "Tonay2", "asdasdas" };

            //var sonuc = aListesi.Where(x => x.Contains(search)).ToList();

            List<DateTime> includedSessions = new List<DateTime>();
            Dictionary<int, string> incluededSaloon = new Dictionary<int, string>();

            var firstAirdate = airDates.FirstOrDefault();
            if (firstAirdate != null)
            {
                var includedAirDatesSessions = sessions.Where(x => x.Time.Date == firstAirdate.Airdate.Date).ToList();
                var includedAirdatesSaloon = saloons.Where(x => x.Id == firstAirdate.Saloon.Id).ToList();

                if (includedAirDatesSessions.Count > 0) 
                {
                    foreach (var item in includedAirDatesSessions)
                    {
                        includedSessions.Add(item.Time);
                    }
                }

                if (includedAirdatesSaloon.Count > 0)
                {
                    foreach (var item in includedAirdatesSaloon)
                    {
                        incluededSaloon.Add(item.Id, item.Name);
                    }
                }
            }


            movie.AirDates = airDates;
            movie.Saloons = saloons;
            movie.Sessions = sessions;
            //İSTEDİĞİM MOVİE NESNESİ ---BİTİŞ---

            var result = new MovieDetailsBookingViewModel
            {
                Airdates = movie.AirDates.ToDictionary(x => x.Id,k=>k.Airdate),
                Saloons = incluededSaloon,
                //Sessions = includedSessions.Count > 0 ? includedSessions : movie.Sessions.Select(x => x.Time).ToList(),
                Sessions = includedSessions,
                Name = movie.Name,
                ImagePath = movie.ImagePath,
            };

            return result;
        }
    }
}
