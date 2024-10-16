using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.ViewModels.SeatingViewModels;
using Sinflex.BLL.Repositories.ViewModels.TicketViewModels;
using Sinflex.Model.Entities;

namespace Sinflex.BLL.Repositories.Concretes
{
    public class TicketService : ITicketService
    {

        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Saloon> _saloonRepository;
        private readonly IRepository<Seat> _seatRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public TicketService(IRepository<Saloon> saloonRepository, IRepository<Seat> seatRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IRepository<Ticket> ticketRepository, IRepository<Movie> movieRepository)
        {

            _saloonRepository = saloonRepository;
            _seatRepository = seatRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _ticketRepository = ticketRepository;
            _movieRepository = movieRepository;

        }

        public async Task<TicketViewModel> GenerateTicket(SeatingViewModel seatingViewModel)
        {
            var result = new TicketViewModel();

            var saloon = _saloonRepository.GetbyId(seatingViewModel.SelectedSaloonId);
            var contextUser = _httpContextAccessor.HttpContext.User;
            var movie = _movieRepository.GetbyId(seatingViewModel.SelectedMovieId);
            var user = await _userManager.GetUserAsync(contextUser);

            if (user != null)
            {
                var seatList = new List<Seat>();

                foreach (var item in seatingViewModel.Seats)
                {
                    var seat = _seatRepository
                        .GetAllQ()
                        .Where(x => x.Place == item.Value)
                        .FirstOrDefault();

                    seatList.Add(seat);
                }

                var ticket = new Ticket()
                {
                    User = user,
                    Seats = seatList,
                    PurchaseDate = DateTime.Now,
                    PurchasePrice = 5,
                    Saloon=saloon,
                    Movie=movie,
                };

                var ticketsCreateResult = await _ticketRepository.Create(ticket);
                if (ticketsCreateResult == "Kayıt işlemi başarılı")
                {
                    result.SelectedSeat= string.Join(",", seatList.Select(x => x.Place));
                    result.TicketNumber=ticket.MasterId.ToString().Split('-')[0];
                    result.MovieName=movie.Name;
                    result.SaloonName=saloon.Name;
                    result.SelectedAirdate = seatingViewModel.SelectedAirdate;
                    result.SelectedSession=seatingViewModel.SelectedSession;
                }
            }

            return result;
        }

    }
}
