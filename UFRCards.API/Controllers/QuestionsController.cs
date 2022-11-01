using Microsoft.AspNetCore.Mvc;
using UFRCards.Business.Interfaces;
using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.API.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Question>> GetQuestions()
    {
        var basic = await _questionService.GetQuestionsAsync(QuestionType.Basic);
        var complex = await _questionService.GetQuestionsAsync(QuestionType.Complex);

        var result = basic.Concat(complex);
        
        return Ok(result);
    }
}