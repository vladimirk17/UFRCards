using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Data.Utilities;

public static class DbInitializer
{
    public static async Task Initialize(Context context)
    {
        if (!context.Questions.Any())
        {
            var questions = new List<Question>
            {
                new()
                {
                    QuestionType = QuestionType.Basic,
                    SlotsCount = 0,
                    QuestionText = "Які дії приводили до кар'єрного зросту на заводі?"
                },
                new()
                {
                    QuestionType = QuestionType.Basic,
                    SlotsCount = 0,
                    QuestionText = "Що до вподоби Олегу Віннику?"
                },
                new()
                {
                    QuestionType = QuestionType.Basic,
                    SlotsCount = 0,
                    QuestionText = "Що може стати новим логотипом Радикальної партії?"
                },
                new()
                {
                    QuestionType = QuestionType.Complex,
                    SlotsCount = 1,
                    QuestionText = "Твоя дупа така велика, що її можна порівняти з _"
                },
                new()
                {
                    QuestionType = QuestionType.Complex,
                    SlotsCount = 1,
                    QuestionText = "Просто зусередься на _ і успіх прийде до тебе"
                },
                new()
                {
                    QuestionType = QuestionType.Complex,
                    SlotsCount = 1,
                    QuestionText = "Новим резидентом Дія.Сіті став _"
                },
                new()
                {
                    QuestionType = QuestionType.Complex,
                    SlotsCount = 2,
                    QuestionText = "Вони казали ми йобнулись. Вони думали ми не зможемо запхати _ в _. Вони жорстоко помилялись"
                },
            };

            context.Questions.AddRange(questions);
        }

        if (!context.Answers.Any())
        {
            var answers = new List<Answer>
            {
                new() { AnswerText = "Твоя мамка" },
                new() { AnswerText = "Порнушка HD" },
                new() { AnswerText = "Бабця мого друга" },
                new() { AnswerText = "Парад геїв у Москві" },
                new() { AnswerText = "Тепле пиво" },
                new() { AnswerText = "Діти наркомани" },
                new() { AnswerText = "Серійне виробництво дітей на Черкащині" }, 
                new() { AnswerText = "Сир з благородною пліснявою" },
                new() { AnswerText = "Щільна проміжність" },
                new() { AnswerText = "Побачення з власною донькою" },
                new() { AnswerText = "Божеволіти від сексу" },
                new() { AnswerText = "Заіржавілий жовтий Богдан" },
                new() { AnswerText = "Пріла проміжність" },
                new() { AnswerText = "Видалити нижні ребра" },
                new() { AnswerText = "Пісні Монатика" },
                new() { AnswerText = "Інтегруватися на 25 см" },
                new() { AnswerText = "Воля, зібрана в кулак" },
            };
            
            context.Answers.AddRange(answers);
        }

        
        await context.SaveChangesAsync();
    }
}