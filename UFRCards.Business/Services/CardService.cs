using Microsoft.EntityFrameworkCore;
using UFRCards.Business.Interfaces;
using UFRCards.Data;
using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Business.Services;

public class CardService : ICardService
{
    private readonly UfrContext _context;

    public CardService(UfrContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Card>> GetWhiteCardsAsync() =>
        await GetCardsByTypeAsync(CardType.White);

    public async Task<IEnumerable<Card>> GetBlackCardsAsync() => 
        await GetCardsByTypeAsync(CardType.Black);

    private async Task<IEnumerable<Card>> GetCardsByTypeAsync(CardType cardType)
    {
        return await _context.Cards
            .Where(x => x.CardType == cardType)
            .ToArrayAsync();
    }
}