using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameSessionSettings
{
    public int PlayersCount { get; set; }
    public int MaxRounds { get; set; }
    public int RoundsPassed { get; set; }
    public int CurrentRound { get; set; }
}