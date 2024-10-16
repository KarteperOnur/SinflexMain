using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinflex.Model.Entities;

namespace Sinflex.DAL.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.PurchaseDate).IsRequired(true);
            builder.Property(x => x.PurchasePrice).IsRequired(true);
        }
    }
}
