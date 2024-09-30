namespace Sinflex.BLL.Repositories.ViewModels.BookingSaloonViewModels
{
    public class BookingSaloonViewModel
    {
        //public string Name { get; set; }
        public Dictionary<int, string> Saloons { get; set; }
        public Dictionary<int, DateTime> Airdates { get; set; }
        public Dictionary<int, DateTime> Sessions { get; set; }


    }
}
