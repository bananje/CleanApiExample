namespace FinBeatTestExercise.Infrastructure.Migrations.Utils;

public class FilterParser
{
    public static Dictionary<string, string> ParseFilter(string filter)
    {
        if (string.IsNullOrEmpty(filter))
            return new Dictionary<string, string>();

        if (filter.StartsWith("?filter="))
            filter = filter.Substring("?filter=".Length);

        return filter
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split('=', 2))
            .ToDictionary(split => split[0].Trim(), split => split.Length > 1 ? split[1].Trim() : string.Empty);
    }
}
