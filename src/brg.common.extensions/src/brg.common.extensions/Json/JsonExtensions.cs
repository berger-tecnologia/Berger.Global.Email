using System.Text.Json;

namespace brg.common.extensions.Json
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static T FromJson<T>(this string json) => JsonSerializer.Deserialize<T>(json, _options);
        public static string ToJson<T>(this T obj) => JsonSerializer.Serialize<T>(obj, _options);
    }
}