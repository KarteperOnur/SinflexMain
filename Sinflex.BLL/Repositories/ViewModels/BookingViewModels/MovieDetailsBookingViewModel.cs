namespace Sinflex.BLL.Repositories.ViewModels.BookingViewModels
{
    public class MovieDetailsBookingViewModel
	{
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        //public List<string> Saloons { get; set; }
        //public List<int> SaloonId { get; set; }
        public Dictionary<int, string> Saloons { get; set; }
        public List<DateTime> Sessions { get; set; }
        //public List<DateTime> Airdates { get; set; }
        public Dictionary<int,DateTime> Airdates { get; set; }

    }
}
