using APBD_PJATK_Cw4_s30786.DTOs;

namespace APBD_PJATK_Cw4_s30786.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync();
    Task<IEnumerable<PcGetByIdComponentDto>?> GetComponentsByIdAsync(int id);
    Task<PcPostResponseDto> CreateAsync(PcPostRequestDto dto);
    Task<bool> UpdateAsync(int id, PcPutRequestDto dto);
    Task<bool> DeleteAsync(int id);
}
