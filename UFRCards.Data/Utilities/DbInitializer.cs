using UFRCards.Data.Entities;
using UFRCards.Data.Enums;

namespace UFRCards.Data.Utilities;

public static class DbInitializer
{
    public static async Task Initialize(Context context)
    {
        if (context.Questions.Any())
        {
            return;
        }

        
        await context.SaveChangesAsync();
    }
}