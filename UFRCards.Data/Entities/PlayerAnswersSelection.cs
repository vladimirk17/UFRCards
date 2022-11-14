using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class PlayerAnswersSelection : IHasId<int>
{
    public int Id { get; set; }
    
    public int GameRoundId { get; set; }
    public GameRound GameRound { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
}