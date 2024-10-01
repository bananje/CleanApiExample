using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace FinBeatTestExercise.Application.Features.Results;

public sealed record Result<T>
{
    public T Value { get; }

    public Error Error { get; }

    public bool IsSucceeded { get; }

    [JsonConstructor]
    private Result(T value, bool isSucceeded, Error error = default)
    {
        IsSucceeded = isSucceeded;
        Value = value;
        Error = error;
    }

    private Result(bool isSucceeded)
    {
        Error = default;
        IsSucceeded = isSucceeded;
        Value = default!;
    }

    public static Result<T> Succes(T value) => new(value, true);


    public static Result<T> Failure(Error error) => new(default!, false, error);

    public TNextValue MatchResult<TNextValue>(Func<T, TNextValue> onValue, Func<Error, TNextValue> onError)
    {
        if (!IsSucceeded)
        {
            return onError(Error);
        }

        return onValue(Value);
    }
}

public sealed record Result
{
    public Error Error { get; }

    public bool IsSucceeded { get; }

    [JsonConstructor]
    private Result(bool isSucceeded, Error error = default)
    {
        IsSucceeded = isSucceeded;
        Error = error;
    }

    private Result(bool isSucceeded)
    {
        Error = default;
        IsSucceeded = isSucceeded;
    }

    public static Result Succes() => new(true);

    public static Result Failure(Error error) => new(false, error);

    public TNextValue MatchResult<TNextValue>(Func<bool, TNextValue> onValue, Func<Error, TNextValue> onError)
    {
        if (!IsSucceeded)
        {
            return onError(Error);
        }

        return onValue(IsSucceeded);
    }
}
