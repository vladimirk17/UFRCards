using Microsoft.AspNetCore.Mvc;
using UFRCards.Business.Interfaces;
using UFRCards.Data.Entities;

namespace UFRCards.API.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly ICardService _cardService;

    public QuestionsController(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Question>> GetCards()
    {
        var whiteCards = await _cardService.GetAnswersAsync();
        var blackCards = await _cardService.GetQuestionsAsync();

        var result = whiteCards.Concat(blackCards);
        
        return Ok(result);
    }
}