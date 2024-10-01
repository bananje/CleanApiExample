namespace FinBeatTestExercise.Contracts;

public record AbstractObjectModel
{
    public int Code { get; init; }

    public string Value { get; init; } = string.Empty;
}
