using BusinessLogic.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Controllers;

[Route("[controller]")]
[ApiController]
public class MonstersController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public MonstersController(ApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    [HttpGet]
    [Route("getrandom")]
    public JsonResult GetRandomMonster()
    {
        var rnd = new Random().Next(1, _dbContext.Monsters.Count());
        return new JsonResult(_dbContext.Monsters.ElementAt(rnd));
    }
}
