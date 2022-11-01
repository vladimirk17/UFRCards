using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class Player : IHasId<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public int GameRoomId { get; set; }
    public GameRoom GameRoom { get; set; }
    public ICollection<Answer> Answers { get; set; }
}