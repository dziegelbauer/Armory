namespace ArmoryWeb.Models;

public record Character
{
    public int Id;
    public string Name;
    public List<Item> Equipment;
}