using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Business.Interfaces;

public interface IQuestionService
{
    Task<IEnumerable<Answer>> GetAnswersAsync();
    Task<IEnumerable<Question>> GetQuestionsAsync(QuestionType questionType);
}