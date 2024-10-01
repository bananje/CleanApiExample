using Newtonsoft.Json;
using System.Net;

namespace FinBeatTestExercise.Application.Features.Results;

public readonly record struct Error
{
    [JsonProperty]
    public string Description { get; }

    [JsonProperty]
    public HttpStatusCode RelatedStatusCode { get; }

    [JsonConstructor]
    public Error(HttpStatusCode code, string description)
    {
        Description = description;
        RelatedStatusCode = code;
    }
}
