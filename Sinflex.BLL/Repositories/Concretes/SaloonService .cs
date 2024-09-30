using Microsoft.EntityFrameworkCore;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.ViewModels.BookingSaloonViewModels;
using Sinflex.BLL.Repositories.ViewModels.BookingViewModels;
using Sinflex.Model.Entities;

namespace Sinflex.BLL.Repositories.Concretes
{
    public class SaloonService : ISaloonService
    {
        public readonly IRepository<Movie> _movieRepository;
        public readonly IRepository<Session> _sessionRepository;
        public readonly IRepository<AirDate> _airDateRepository;
        public readonly IRepository<Saloon> _saloonRepository;


        public SaloonService(IRepository<Saloon> saloonRepository, IRepository<Session> sessionRepository, IRepository<AirDate> airDateRepository, IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
            _sessionRepository = sessionRepository;
            _airDateRepository = airDateRepository;
            _saloonRepository = saloonRepository;
        }

        public BookingSaloonViewModel GetSaloonByAirdate(DateTime airDate)
        {
            var saloonIds = _airDateRepository
                .GetAllQ()
                .Where(x => x.Airdate.Equals(airDate))
                .Select(x => x.Saloon.Id)
                .ToList();

            Dictionary<int, string> salonDictionary = new Dictionary<int, string>();

            foreach (var id in saloonIds)
            {
                var saloon = _saloonRepository.GetbyId(id);

                var saloonName = saloon.Name;
                var saloonId = saloon.Id;
                salonDictionary.Add(saloonId, saloonName);
            }


            var result = new BookingSaloonViewModel
            {
                Saloons = salonDictionary

                //Airdates = movie.AirDates.ToDictionary(x => x.Id, k => k.Airdate),
                //Saloons = incluededSaloon,
                //Sessions = includedSessions,
                //Name = incluededSaloon.FirstOrDefault().Value,

            };

            return result;

        }

        public BookingSaloonViewModel GetSessionsByAirdateSaloonId(int saloonid, DateTime airDate)
        {
            var sessions = _sessionRepository
                .GetAllQ()
                .Include(p => p.Saloons)
                .Where(x => x.Saloons.Id.Equals(saloonid) && x.Time.Date.Equals(airDate.Date)).ToList();

            Dictionary<int, DateTime> SessionDictionary = new Dictionary<int, DateTime>();
            foreach (var x in sessions)
            {
                var saloon = x.Saloons.Id;
                var saloonName = x.Saloons.Name;
                var movie = x.Movies.Id;
                var airdate = x.Time.Date;
                SessionDictionary.Add(saloon, airdate);
            }
            var result = new BookingSaloonViewModel
            {
                Sessions = SessionDictionary
            };
            return result;

        }




    }
}
//var saloonIds = _airDateRepository
// .GetAllQ()
// .Where(x => x.Airdate.Equals(airDate))
// .Select(x => x.Saloon.Id)
// .ToList();
//Dictionary<int, string> salonDictionary = new Dictionary<int, string>();

//foreach (var id in saloonIds)
//{
//    var saloon = _saloonRepository.GetbyId(id);

//    var saloonName = saloon.Name;
//    var saloonId = saloon.Id;
//    salonDictionary.Add(saloonId, saloonName);
//}




//var result = new BookingSaloonViewModel
//{
//    Saloons = salonDictionary

//    //Airdates = movie.AirDates.ToDictionary(x => x.Id, k => k.Airdate),
//    //Saloons = incluededSaloon,
//    //Sessions = includedSessions,
//    //Name = incluededSaloon.FirstOrDefault().Value,

//};

//return result;