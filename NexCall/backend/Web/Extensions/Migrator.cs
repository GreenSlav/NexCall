using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions;

/// <summary>
/// Класс работы с миграциями
/// </summary>
public static class Migrator
{
    /// <summary>
    /// Применение миграций
    /// </summary>
    /// <param name="app">Хост</param>
    public static void ApplyMigrations(this IHost app)
    {
        try
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EfContext>();
                dbContext.Database.Migrate();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Произошла ошибка при применении миграций: {e}");
            throw;
        }
    }
}