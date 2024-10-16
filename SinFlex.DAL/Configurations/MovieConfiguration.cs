using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinflex.Model.Entities;

namespace Sinflex.DAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(255);

            builder.HasMany(p => p.Saloons)
                .WithMany(p => p.Movies);

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Movie);

        }
    }
}
