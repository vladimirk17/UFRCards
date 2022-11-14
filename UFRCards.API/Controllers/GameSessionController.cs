using Microsoft.AspNetCore.Mvc;
using UFRCards.Business.Dto;
using UFRCards.Business.Interfaces;

namespace UFRCards.API.Controllers;

public class GameSessionController : BaseApiController
{
    private readonly IGameSessionService _gameSessionService;

    public GameSessionController(IGameSessionService gameSessionService)
    {
        _gameSessionService = gameSessionService;
    }

    [HttpGet("{id:int}", Name = "GetSession")]
    public async Task<ActionResult<GameSessionDto>> GetSession(int id)
    {
        if (id <= 0 || !ModelState.IsValid)
        {
            return BadRequest(new ProblemDetails { Title = "Incorrect request" });
        }
        
        var result = await _gameSessionService.GetGameSession(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateGameSession(GameSessionDto gameSessionDto)
    {
        if (gameSessionDto == null)
        {
            return BadRequest();
        }
        
        var gameSessionId = await _gameSessionService.CreateGameSession(gameSessionDto);

        return CreatedAtRoute(nameof(GetSession), new { id = gameSessionId }, gameSessionId);
    }
}