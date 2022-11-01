using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameRoomSettings
{
    public int UsersCount { get; set; }
    public int MaxRounds { get; set; }
    public int RoundsPassed { get; set; }
    public int CurrentRound { get; set; }
}