using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BusinessLogic.Controllers;

[Route("[controller]")]
[ApiController]
public class FightsController : ControllerBase
{
	private IFight _fight;

	public FightsController(IFight fight) => _fight = fight;

	[HttpPost]
	[Route("getlogfight")]
	public JsonResult GetLogFight([FromBody] MonsterAndPlayer monsterAndPlayer)
	{
        return new JsonResult(_fight.GetFightResult(monsterAndPlayer.Monster, monsterAndPlayer.Player));
    }
}
