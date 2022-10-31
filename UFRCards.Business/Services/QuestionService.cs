using Microsoft.EntityFrameworkCore;
using UFRCards.Business.Interfaces;
using UFRCards.Data;
using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Business.Services;

public class CardService : ICardService
{
    private readonly Context _context;

    public CardService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetAnswersAsync() =>
        await GetCardsByTypeAsync(QuestionType.Complex);

    public async Task<IEnumerable<Question>> GetQuestionsAsync() => 
        await GetCardsByTypeAsync(QuestionType.Basic);

    private async Task<IEnumerable<Question>> GetCardsByTypeAsync(QuestionType questionType)
    {
        return await _context.Questions
            .Where(x => x.QuestionType == questionType)
            .ToArrayAsync();
    }
}