using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinflex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.DAL.Configurations
{
    public class SaloonConfiguration : IEntityTypeConfiguration<Saloon>
    {
        public void Configure(EntityTypeBuilder<Saloon> builder)
        {
            builder.Property(x => x.Name).IsRequired(true);

            builder.HasMany(x => x.Seats)
                .WithOne(x => x.Saloon);
        }
    }
}
