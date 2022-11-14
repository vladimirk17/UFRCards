using UFRCards.Data.Enums;
using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameSessionSettings
{
    public int MaxPlayers { get; set; } = 3;
    public int PlayersCount { get; set; }
    public int MaxRounds { get; set; }
    public int RoundsPassed { get; set; }
    public int CurrentRound { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
}