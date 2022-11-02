using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class GameRound : IHasId<int>
{
    public int Id { get; set; }
    public int RoundNumber { get; set; }

    public ICollection<PlayerAnswersSelection> PlayerAnswersSelections { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
}