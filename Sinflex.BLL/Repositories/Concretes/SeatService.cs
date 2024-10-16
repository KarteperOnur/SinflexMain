using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.ViewModels.SeatingViewModels;
using Sinflex.Model.Entities;

namespace Sinflex.BLL.Repositories.Concretes
{
    public class SeatService : ISeatService
    {
        public readonly IRepository<Saloon> _saloonRepository;
        public readonly IRepository<Seat> _seatRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public SeatService(IRepository<Saloon> saloonRepository, IRepository<Seat> seatRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _saloonRepository = saloonRepository;
            _seatRepository = seatRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<bool> InsertSeat(SeatingViewModel seatingViewModel)
        {
            var result = false; 
            var saloon = _saloonRepository.GetbyId(seatingViewModel.SelectedSaloonId);
            var contextUser = _httpContextAccessor.HttpContext.User;

            var user = await _userManager.GetUserAsync(contextUser);

            if (user != null)
            {
                foreach (var item in seatingViewModel.Seats)
                {
                    var seat = new Seat()
                    {
                        Saloon = saloon,
                        User = user,
                        IsAvailable = false,
                        IsReserved = true,
                        IsSold = true,
                        Place = item.Value
                    };

                    //ara kontrol
                    var addedSeat = _seatRepository
                        .GetAllQ()
                        .Where(x => x.Saloon.Id.Equals(seatingViewModel.SelectedSaloonId) && x.Place.Equals(item.Value)/* && x.Session.Id.Equals(seatingViewModel.SelectedSession)*/)
                        .FirstOrDefault();

                    if (addedSeat != null)
                    {
                        var seatCreateResult = await _seatRepository.Create(seat);

                        if (seatCreateResult != "Kayıt işlemi başarılı")
                            return false;
                    }
                    else
                        return false;
                }

                result = true;
            }
            else
                result = false;

            return result;
        }

    }

}


