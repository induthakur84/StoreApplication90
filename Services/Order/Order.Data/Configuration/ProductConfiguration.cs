using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entites;

namespace Order.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(p => p.Categories)
                .WithMany(u => u.Products)
                .UsingEntity(j =>j.ToTable("ProductCategories"));
        }
    }
}
