using UFRCards.Data.Enums;

namespace UFRCards.Data.Entities;

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public QuestionType QuestionType { get; set; }
    public Category Category { get; set; }
}