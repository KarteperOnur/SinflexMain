using Sinflex.Model.Base;

namespace Sinflex.Model.Entities
{
    public class Seat : BaseEntity
    {
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
        public bool IsAvailable { get; set; }
        public string Place { get; set; }
        public virtual AppUser? User { get; set; }
        public virtual Saloon Saloon { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
