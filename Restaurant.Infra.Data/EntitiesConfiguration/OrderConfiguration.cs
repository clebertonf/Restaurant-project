using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infra.Data.EntitiesConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> order)
    {
        order.HasKey((item) => item.Id);
        order.Property(item => item.Date);
        order.Property(item => item.TableNumber);
        order.Property(item => item.Total);
        order.HasMany(o => o.MenuItems).WithOne(me => me.Order).HasForeignKey(m => m.Id);
    }
}