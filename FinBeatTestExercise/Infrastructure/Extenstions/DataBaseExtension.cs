using FinBeatTestExercise.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace FinBeatTestExercise.Infrastructure.Extenstions;

public static class DataBaseExtension
{
    public static void ConfigureDataBase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FinBeatDbContext>(opt =>
           opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FinBeatDbContext>();

        if (dbContext.Database.IsRelational())
        {
            dbContext.Database.Migrate();
        }
    }
}
