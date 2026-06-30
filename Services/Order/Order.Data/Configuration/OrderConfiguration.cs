using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entites;

namespace Order.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(u => u.OrderModels)
                .HasForeignKey(o=>o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //delete behaviou restric it prevent user to delte

            // if any order exist
            //if user 10 order then you are not able to delted the user 

            // first you need delted the orders then we are able dleted the user
        }
    }
}
