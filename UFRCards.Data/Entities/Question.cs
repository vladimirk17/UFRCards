using UFRCards.Data.Enums;
using UFRCards.Data.Interfaces;

namespace UFRCards.Data.Entities;

public class Question : IHasId<int>
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public int SlotsCount { get; set; }
    public QuestionType QuestionType { get; set; }
    public Category Category { get; set; }
}