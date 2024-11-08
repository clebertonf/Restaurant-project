using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infra.Data.EntitiesConfiguration;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> menuItem)
    {
        menuItem.HasKey((item) => item.Id);
        menuItem.Property(item => item.Name).HasMaxLength(100).IsRequired();
        menuItem.Property(item => item.Description).HasMaxLength(200).IsRequired();
        menuItem.Property(item => item.Price).HasPrecision(10,2);
        menuItem.Property(item => item.Available).HasDefaultValue(false);
    }
}