using FinBeatTestExercise.Application.Contracts;
using FinBeatTestExercise.Application.Services;
using FinBeatTestExercise.Infrastructure.DAL.Repository;
using FinBeatTestExercise.Infrastructure.Extenstions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var configuration = builder.Configuration;

    builder.Services.ConfigureDataBase(configuration);

    builder.Services.AddTransient<IAbstractObjectRepository, AbstractObjectRepository>();
    builder.Services.AddTransient<IAbstractObjectService, AbstractObjectService>();

}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.ApplyMigrations();

    app.Run();
}
