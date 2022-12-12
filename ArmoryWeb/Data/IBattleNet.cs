using ArmoryWeb.Models;

namespace ArmoryWeb.Data;

public interface IBattleNet
{
    public Character GetCharacter(string name, string realm, int region);
}