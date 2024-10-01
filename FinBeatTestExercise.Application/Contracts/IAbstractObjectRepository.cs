using FinBeatTestExercise.Domain;

namespace FinBeatTestExercise.Application.Contracts;

public interface IAbstractObjectRepository
{
    Task AddAbstractObjectAsync(AbstractObject value);

    Task AddAbstractObjectsAsync(IReadOnlyCollection<AbstractObject> values);

    Task RemoveAllObjectsAsync();

    Task<IReadOnlyCollection<AbstractObject>> GetObjectsByFilterAsync(Dictionary<string, string> filters);
}
