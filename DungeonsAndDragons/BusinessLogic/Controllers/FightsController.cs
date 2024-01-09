using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BusinessLogic.Controllers;

[Route("[controller]")]
[ApiController]
public class FightsController : ControllerBase
{

	[HttpPost]
	[Route("getlogfight")]
	public JsonResult GetLogFight([FromBody] MonsterAndPlayer monsterAndPlayer)
	{
		throw new NotImplementedException();
	}
}
