using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UFRCards.API.Hubs;
using UFRCards.API.Interfaces;
using UFRCards.Business.Dto;
using UFRCards.Business.Interfaces;
using UFRCards.Data.Entities;

namespace UFRCards.API.Controllers;

public class AnswersController : BaseApiController
{
    private readonly IQuestionService _questionService;
    private readonly IHubContext<GameHub, IGameClient> _gameHubContext;

    public AnswersController(IQuestionService questionService, IHubContext<GameHub, IGameClient> _gameHubContext)
    {
        _questionService = questionService;
        this._gameHubContext = _gameHubContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<Answer>> GetAnswers()
    {
        var result = await _questionService.GetAnswersAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddAnswer(AnswerInputDto answerInputDto)
    {
        //Add answer to db
        //Check if all players sent answers
        //If yes, invoke Hub action to finish round
        
        //await _gameHubContext.Groups

        throw new NotImplementedException();
    }
}