using UFRCards.Data.Enums;

namespace UFRCards.Data.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardText { get; set; }
    public CardType CardType { get; set; }
}