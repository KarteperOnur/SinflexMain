namespace Sinflex.BLL.Repositories.ViewModels.SeatingViewModels
{
    public class SeatingViewModel
    {
        public Dictionary<int, string> Seats { get; set; }
        public int SelectedSaloonId { get; set; }
        public string SelectedSession { get; set; }//
        public string SelectedAirdate { get; set; }//
        public int SelectedMovieId { get; set; }//

    }
}
