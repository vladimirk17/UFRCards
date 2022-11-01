using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameRoom : IHasId<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    public ICollection<Question> Questions { get; set; }
    public ICollection<Player> Players { get; set; }
    public ICollection<GameRound> GameRounds { get; set; }
    public GameRoomSettings GameRoomSettings { get; set; }
}