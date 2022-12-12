using ArmoryWeb.Data;
using ArmoryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmoryWeb.Pages;

[BindProperties]
public class IndexModel : PageModel
{
    private readonly IBattleNet _bnet;
    public Character? Character { get; set; }
    public string Name { get; set; }
    public string Realm { get; set; }
    public int Region { get; set; }

    public IndexModel(IBattleNet bnet)
    {
        _bnet = bnet;
    }

    public void OnGet()
    {
        Character = null;
    }

    public IActionResult OnPost()
    {
        Character = _bnet.GetCharacter(Name, Realm, Region);
        
        return Page();
    }
}