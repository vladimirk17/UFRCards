using UFRCards.Data.Enums;
using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameSession : IHasId<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public bool IsActive { get; set; }
    public GameSessionStatus GameSessionStatus { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<Player> Players { get; set; }
    public ICollection<GameRound> GameRounds { get; set; }
    public GameSessionSettings GameSessionSettings { get; set; }
}