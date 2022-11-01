using Microsoft.EntityFrameworkCore;
using UFRCards.Business.Interfaces;
using UFRCards.Data;
using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Business.Services;

public class QuestionService : IQuestionService
{
    private readonly Context _context;

    public QuestionService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetQuestionsAsync(QuestionType questionType) => 
        await GetQuestionsByTypeAsync(questionType);
    
    public async Task<IEnumerable<Answer>> GetAnswersAsync() => await _context.Answers.ToArrayAsync();

    private async Task<IEnumerable<Question>> GetQuestionsByTypeAsync(QuestionType questionType)
    {
        return await _context.Questions
            .Where(x => x.QuestionType == questionType)
            .ToArrayAsync();
    }
}