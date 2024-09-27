using FinBeatTestExercise.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinBeatTestExercise.Infrastructure.DAL;

public class FinBeatDbContext : DbContext
{
    public FinBeatDbContext(DbContextOptions<FinBeatDbContext> options) : base(options) { }

    public DbSet<AbstractObject> AbstractObjects { get; set; }
}
