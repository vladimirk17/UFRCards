using UFRCards.Data.Entities;

namespace UFRCards.Business.Interfaces;

public interface ICardService
{
    Task<IEnumerable<Question>> GetAnswersAsync();
    Task<IEnumerable<Question>> GetQuestionsAsync();
}