using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System;

namespace UI.Pages;

public class GameModel : PageModel
{
    private readonly string GetMonsterUrl = "https://localhost:7180/Monsters/getrandom";
    private readonly string BusinessLogicUrl = "https://localhost:7180/Fights/getlogfight";

    public Monster? Monster { get; set; }

    [BindProperty]
    public Player Player { get; set; } = new();

    public Result? Result { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPost()
    {
        if (!ModelState.IsValid) return;
		using var client = new HttpClient();
		var monster = await client.GetFromJsonAsync<Monster>(GetMonsterUrl);
		Monster = monster!;
        var resultFight = await client.PostAsJsonAsync(BusinessLogicUrl, new MonsterAndPlayer(Monster, Player));
		Result = await resultFight.Content.ReadFromJsonAsync<Result>();
	}

}
