using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> entity)
    {
        entity.HasKey(ct => ct.Id);
        entity.Property(ct => ct.Abbreviation).HasMaxLength(30).IsRequired();
        entity.Property(ct => ct.Name).HasMaxLength(150).IsRequired();
    }
}
