using FinBeatTestExercise.Application.Contracts;
using FinBeatTestExercise.Application.Features.Results;
using FinBeatTestExercise.Contracts;
using FinBeatTestExercise.Domain.Errors;
using FinBeatTestExercise.Domain.Models;

namespace FinBeatTestExercise.Application.Services;

public class AbstractObjectService(
    IAbstractObjectRepository repository,
    ILogger<AbstractObjectService> logger) : IAbstractObjectService
{
    public async Task<Result> CreateAbstractObjectAsync(AbstractObjectModel value)
    {
        try
        {
            await repository.RemoveAllObjectsAsync();

            // mapping
            AbstractObject obj = new() { Code = value.Code, Value = value.Value};

            await repository.AddAbstractObjectAsync(obj);

            logger.LogInformation($"Успешное добавление объекта {nameof(value)} c кодом: {value.Code}");

            return Result.Succes();
        }
        catch
        {
            return Result.Failure(Errors.NotCreated);
        }
    }

    public async Task<Result> CreateAbstractObjectsAsync(IReadOnlyCollection<AbstractObjectModel> values)
    {
        try
        {
            await repository.RemoveAllObjectsAsync();

            // mapping
            List<AbstractObject> objects = [];

            foreach (var item in values)
            {
                AbstractObject obj = new() { Code = item.Code, Value = item.Value };

                objects.Add(obj);
            }

            await repository.AddAbstractObjectsAsync(objects);

            logger.LogInformation("Успешное добавление объектов");

            return Result.Succes();
        }
        catch
        {
            return Result.Failure(Errors.NotCreated);
        }
    }

    public async Task<Result<IReadOnlyCollection<AbstractObjectModel>>> GetAbstractObjectsByFilterAsync(Dictionary<string, string> filters)
    {
        try
        {
            var result = await repository.GetObjectsByFilterAsync(filters);

            if (result.Count is 0)
            {
                return Result<IReadOnlyCollection<AbstractObjectModel>>.Failure(Errors.NotFound);
            }

            // mapping
            var mappingResult = result.Select((item) => new AbstractObjectModel
            {
                Code = item.Code,
                Value = item.Value
            }).ToList();

            return Result<IReadOnlyCollection<AbstractObjectModel>>.Succes(mappingResult);
        }
        catch
        {
            return Result<IReadOnlyCollection<AbstractObjectModel>>.Failure(Errors.BadRequest);
        }
    }
}
