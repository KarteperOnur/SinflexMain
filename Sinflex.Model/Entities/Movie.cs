using Sinflex.Model.Base;

namespace Sinflex.Model.Entities
{
    public class Movie : BaseEntity
    {

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
		public string AgeRestriction { get; set; }
		public string Director { get; set; }




		//MAPPING
		public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public ICollection<Saloon> Saloons { get; set; } = new HashSet<Saloon>();
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
        public ICollection<Booth> Booths { get; set; } = new HashSet<Booth>();
        public ICollection<AirDate> AirDates { get; set; } = new HashSet<AirDate>();

	}
}
