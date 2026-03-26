using System.Text.RegularExpressions;

namespace fitnessControlAPI.Persistence;

public static class SnakeCaseNamingConvention
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        
        return Regex.Replace(input, @"(?<=[a-z0-9])[A-Z]", m => "_" + m.Value).ToLower();
    }
}
