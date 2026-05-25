using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data.Configurations;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> entity)
    {
        entity.HasKey(pc => new { pc.PcId, pc.ComponentCode });
        entity.Property(pc => pc.ComponentCode).HasColumnType("char(10)");

        entity.HasOne(pc => pc.Pc)
              .WithMany(p => p.PcComponents)
              .HasForeignKey(pc => pc.PcId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(pc => pc.Component)
              .WithMany(c => c.PcComponents)
              .HasForeignKey(pc => pc.ComponentCode)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
