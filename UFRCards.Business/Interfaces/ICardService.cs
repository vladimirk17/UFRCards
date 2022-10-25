using UFRCards.Data.Entities;

namespace UFRCards.Business.Interfaces;

public interface ICardService
{
    Task<IEnumerable<Card>> GetWhiteCardsAsync();
    Task<IEnumerable<Card>> GetBlackCardsAsync();
}