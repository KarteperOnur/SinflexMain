using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.ViewModels.BookingViewModels
{
	public class MovieDetailsBookingViewModel
	{
        public string Name { get; set; }
        public string ImagePath { get; set; }
        //public List<string> Saloons { get; set; }
        //public List<int> SaloonId { get; set; }
        public Dictionary<int, string> Saloons { get; set; }
        public List<DateTime> Sessions { get; set; }
        public List<DateTime> Airdates { get; set; }
        
    }
}
