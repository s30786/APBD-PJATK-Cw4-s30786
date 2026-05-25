using Microsoft.EntityFrameworkCore;
using APBD_PJATK_Cw4_s30786.Data;
using APBD_PJATK_Cw4_s30786.DTOs;
using APBD_PJATK_Cw4_s30786.Models;

namespace APBD_PJATK_Cw4_s30786.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _db;

    public PcService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PcGetAllDto>> GetAllAsync()
    {
        return await _db.Pcs
            .Select(p => new PcGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PcGetByIdComponentDto>?> GetComponentsByIdAsync(int id)
    {
        var exists = await _db.Pcs.AnyAsync(p => p.Id == id);
        if (!exists) return null;

        return await _db.PcComponents
            .Where(pc => pc.PcId == id)
            .Select(pc => new PcGetByIdComponentDto
            {
                ComponentCode = pc.ComponentCode,
                ComponentName = pc.Component.Name,
                Amount = pc.Amount
            })
            .ToListAsync();
    }

    public async Task<PcPostResponseDto> CreateAsync(PcPostRequestDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _db.Pcs.Add(pc);
        await _db.SaveChangesAsync();

        return new PcPostResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PcPutRequestDto dto)
    {
        var pc = await _db.Pcs.FindAsync(id);
        if (pc is null) return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _db.Pcs.FindAsync(id);
        if (pc is null) return false;

        _db.Pcs.Remove(pc);
        await _db.SaveChangesAsync();
        return true;
    }
}
