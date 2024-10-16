using Sinflex.Model.Base;

namespace Sinflex.Model.Entities
{
    public class Ticket : BaseEntity
    {

        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }

        public virtual Saloon Saloon { get; set; }
        public virtual Movie Movie { get; set; }

        //MAPPING
        public virtual AppUser User { get; set; }
        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
