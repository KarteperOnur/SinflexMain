using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinflex.Model.Entities;

namespace Sinflex.DAL.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.PurchaseDate).IsRequired(true);
            builder.Property(x => x.SaleType).IsRequired(true);
        }
    }
}
