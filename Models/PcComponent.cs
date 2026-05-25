namespace APBD_PJATK_Cw4_s30786.Models;

public class PcComponent
{
    public int PcId { get; set; }
    public string ComponentCode { get; set; } = null!;
    public int Amount { get; set; }

    public Pc Pc { get; set; } = null!;
    public Component Component { get; set; } = null!;
}
