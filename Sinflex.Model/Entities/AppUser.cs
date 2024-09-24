using Microsoft.AspNetCore.Identity;
using Sinflex.Core.Enums;



namespace Sinflex.Model.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        //MESLEK
        public string? Profession { get; set; }
        //EKONOMIK DURUM
        public string? EconomicalStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public bool? LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        //VIP - STUDENT - REGULAR
        public UserType? UserType { get; set; }
        //Reservation

        //MAPPING
        public ICollection<Ticket> Tickets { get; set; }=new HashSet<Ticket>();

       
    }
}
