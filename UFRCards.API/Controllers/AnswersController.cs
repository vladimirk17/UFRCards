using Microsoft.AspNetCore.Mvc;
using UFRCards.Business.Interfaces;
using UFRCards.Data.Entities;

namespace UFRCards.API.Controllers;

public class AnswersController : BaseApiController
{
    private readonly IQuestionService _questionService;

    public AnswersController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Answer>> GetAnswers()
    {
        var result = await _questionService.GetAnswersAsync();

        return Ok(result);
    }
}