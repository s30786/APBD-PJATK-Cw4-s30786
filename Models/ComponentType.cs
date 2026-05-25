namespace APBD_PJATK_Cw4_s30786.Models;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;

    public ICollection<Component> Components { get; set; } = new List<Component>();
}
