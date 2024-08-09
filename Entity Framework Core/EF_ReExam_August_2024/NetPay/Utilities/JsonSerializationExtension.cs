using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetPay.Utilities;

public static class JsonSerializationExtension
{
    public static string SerializationToJson<T>(this T obj, NullValueHandling nullValueHandling = NullValueHandling.Include, Formatting formatting = Formatting.Indented)
    {
        var jsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = nullValueHandling,
            Formatting = formatting,
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter()
            }
        };

        string result = JsonConvert.SerializeObject(obj, jsonSettings);

        return result;
    }
    
    public static T DeserializeFromJson<T>(this string jsonString, NullValueHandling nullValueHandling = NullValueHandling.Include, Formatting formatting = Formatting.Indented)
    {
        var jsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = nullValueHandling,
            Formatting = formatting
        };

        T result = JsonConvert.DeserializeObject<T>(jsonString, jsonSettings)!;

        return result;
    }
}