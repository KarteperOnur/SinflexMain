using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.BLL.Repositories.ViewModels.BookingViewModels
{
    public class MovieDetailsPostViewModel
    {
        public int MovieId { get; set; }
        public int SelectedSaloonId { get; set; }
        public string SelectedAirdate { get; set; }
        public string SelectedSession { get; set; }
        public double PurchasePrice { get; set; }
    }
}
