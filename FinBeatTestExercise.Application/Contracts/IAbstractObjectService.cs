using FinBeatTestExercise.Application.Features.Results;
using FinBeatTestExercise.Contracts;

namespace FinBeatTestExercise.Application.Contracts;

public interface IAbstractObjectService
{
    Task<Result> CreateAbstractObjectAsync(AbstractObjectModel value);

    Task<Result> CreateAbstractObjectsAsync(IReadOnlyCollection<AbstractObjectModel> values);

    Task<Result<IReadOnlyCollection<AbstractObjectModel>>> GetAbstractObjectsByFilterAsync(Dictionary<string, string> filters);
}
