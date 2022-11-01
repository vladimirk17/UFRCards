namespace UFRCards.Data.Entities;

public class GameRound
{
    public int RoundNumber { get; set; }

    public IDictionary<int, IEnumerable<int>> AnswerIdsByPlayerId { get; set; } =
        new Dictionary<int, IEnumerable<int>>();
    
    public int GameRoomId { get; set; }
    public GameRoom GameRoom { get; set; }
}