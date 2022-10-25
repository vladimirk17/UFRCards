using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Data.Utilities;

public static class DbInitializer
{
    public static async Task Initialize(UfrContext context)
    {
        if (context.Cards.Any())
        {
            return;
        }

        var blackCards = new List<Card>
        {
            new()
            {
                CardText = "Black Card 1 Test text",
                CardType = CardType.Black,
            },
            new()
            {
                CardText = "Black Card Test text",
                CardType = CardType.Black,
            }
        };

        var whiteCards = new List<Card>
        {
            new()
            {
                CardText = "White Card 1 Test text",
                CardType = CardType.White,
            },
            new()
            {
                CardText = "White Card 2 Test text",
                CardType = CardType.White,
            },
        };

        context.AddRange(blackCards);
        context.AddRange(whiteCards);
        await context.SaveChangesAsync();
    }
}