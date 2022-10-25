using Microsoft.AspNetCore.Mvc;
using UFRCards.Business.Interfaces;
using UFRCards.Data.Entities;

namespace UFRCards.API.Controllers;

public class CardsController : BaseApiController
{
    private readonly ICardService _cardService;

    public CardsController(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Card>> GetCards()
    {
        var whiteCards = await _cardService.GetWhiteCardsAsync();
        var blackCards = await _cardService.GetBlackCardsAsync();

        var result = whiteCards.Concat(blackCards);
        
        return Ok(result);
    }
}