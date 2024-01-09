﻿using BusinessLogic.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        return new JsonResult(_dbContext.Monsters.ToList()[new Random().Next(_dbContext.Monsters.Count())]);
    }
}