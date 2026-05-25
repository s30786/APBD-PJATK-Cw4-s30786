using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data.Configurations;

public class PcConfiguration : IEntityTypeConfiguration<Pc>
{
    public void Configure(EntityTypeBuilder<Pc> entity)
    {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
        entity.Property(p => p.Weight).HasColumnType("float(5)");
        entity.Property(p => p.CreatedAt).IsRequired();
    }
}
