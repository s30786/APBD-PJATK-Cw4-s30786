using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> entity)
    {
        entity.HasKey(cm => cm.Id);
        entity.Property(cm => cm.Abbreviation).HasMaxLength(30).IsRequired();
        entity.Property(cm => cm.FullName).HasMaxLength(300).IsRequired();
        entity.Property(cm => cm.FoundationDate).IsRequired();
    }
}
