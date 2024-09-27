namespace FinBeatTestExercise.Contracts;

public record FilterModel
{
    public Dictionary<string, string> Filters { get; init; } = new(); 
}