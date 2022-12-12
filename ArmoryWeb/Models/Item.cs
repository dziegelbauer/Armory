using ArmoryWeb.Models.Values;

namespace ArmoryWeb.Models;

public record Item
{
    public int Id;
    public ItemSlot Slot;
    public Quality Quality;
    public string Name;
    public string Image;
    public int Armor;
    public int Strength;
    public int Intelligence;
    public int Agility;
}