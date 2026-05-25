using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> entity)
    {
        entity.HasKey(c => c.Code);
        entity.Property(c => c.Code).HasColumnType("char(10)");
        entity.Property(c => c.Name).HasMaxLength(300).IsRequired();
        entity.Property(c => c.Description).HasColumnType("nvarchar(max)");

        entity.HasOne(c => c.ComponentManufacturer)
              .WithMany(cm => cm.Components)
              .HasForeignKey(c => c.ComponentManufacturersId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.ComponentType)
              .WithMany(ct => ct.Components)
              .HasForeignKey(c => c.ComponentTypesId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
