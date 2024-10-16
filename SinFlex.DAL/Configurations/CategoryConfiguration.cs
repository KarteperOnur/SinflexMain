using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sinflex.Model.Entities;

namespace Sinflex.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.HasOne(x => x.Movies)
                .WithMany(x => x.Categories);


        }



    }
}
