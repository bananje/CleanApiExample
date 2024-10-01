using FinBeatTestExercise.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinBeatTestExercise.Infrastructure.Migrations.Utils;

public class FinBeatDbContextFactory : IDesignTimeDbContextFactory<FinBeatDbContext>
{
    public FinBeatDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FinBeatDbContext>();

        var connectionString = "Username=postgres;Password=09012004;Host=localhost;Port=5432;Database=ReportService;Pooling=true";
        optionsBuilder.UseNpgsql(connectionString);

        return new FinBeatDbContext(optionsBuilder.Options);
    }
}
