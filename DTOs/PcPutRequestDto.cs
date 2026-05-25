namespace APBD_PJATK_Cw4_s30786.DTOs;

public class PcPutRequestDto
{
    public string Name { get; set; } = null!;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}
