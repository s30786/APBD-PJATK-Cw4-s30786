using Microsoft.EntityFrameworkCore;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pc> Pcs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );
        
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturer { Id = 3, Abbreviation = "NVIDIA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) }
        );
        
        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "CPU-I9-001", Name = "Intel Core i9-13900K", Description = "High-end desktop CPU", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "GPU-RTX-01", Name = "NVIDIA RTX 4090", Description = "Flagship gaming GPU", ComponentManufacturersId = 3, ComponentTypesId = 2 },
            new Component { Code = "RAM-DDR5-1", Name = "DDR5 32GB 6000MHz", Description = "High-speed RAM module", ComponentManufacturersId = 2, ComponentTypesId = 3 }
        );
        
        modelBuilder.Entity<Pc>().HasData(
            new Pc { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new Pc { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new Pc { Id = 3, Name = "Workstation Pro Z", Weight = 18.0f, Warranty = 48, CreatedAt = new DateTime(2026, 3, 1, 10, 0, 0), Stock = 3 }
        );
        
        modelBuilder.Entity<PcComponent>().HasData(
            new PcComponent { PcId = 1, ComponentCode = "CPU-I9-001", Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "GPU-RTX-01", Amount = 2 },
            new PcComponent { PcId = 2, ComponentCode = "RAM-DDR5-1", Amount = 4 }
        );
    }
}
