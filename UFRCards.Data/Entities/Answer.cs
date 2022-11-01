using UFRCards.Data.Enums;
using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class Answer : IHasId<int>
{
    public int Id { get; set; }
    public string AnswerText { get; set; }
    public Category Category { get; set; }
}