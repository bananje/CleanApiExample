namespace FinBeatTestExercise.Contracts;

public record CreateAbstractObject
{
    public AbstractObjectModel Value { get; init; } = null!;
}

public record CreateAbstractObjects
{
    public IReadOnlyCollection<AbstractObjectModel> Values { get; init; } = [];
}
