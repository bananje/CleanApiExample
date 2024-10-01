using FinBeatTestExercise.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinBeatTestExercise.Infrastructure.Extenstions;

public static class DataBaseExtension
{
    public static void ConfigureDataBase(
        this Microsoft.Extensions.DependencyInjection.IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FinBeatDbContext>(opt =>
           opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ApplyMigrations(this Microsoft.AspNetCore.Builder.WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FinBeatDbContext>();

        if (dbContext.Database.IsRelational())
        {
            dbContext.Database.Migrate();
        }
    }
}
