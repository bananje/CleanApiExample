using FinBeatTestExercise.Application.Features.Results;
using System.Net;

namespace FinBeatTestExercise.Domain.Errors;

public static class Errors
{
    public static Error NotCreated => new(HttpStatusCode.BadRequest, "Ошибка создания ресурса на сервере");

    public static Error NotFound => new(HttpStatusCode.NotFound, "Запрашиваемые ресурсы не найдены");

    public static Error BadRequest => new(HttpStatusCode.BadRequest, "Невозможно выполнить запрашиваемую операцию");
}
