using System.Text.Json;

namespace Shopping.Aggregator.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode is false)
        {
            throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
        }

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var deserializedObject = JsonSerializer.Deserialize<T>(dataAsString, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (deserializedObject is null)
        {
            throw new ApplicationException($"Something went wrong deserializing the string: {dataAsString} as {typeof(T).Name}");
        }

        return deserializedObject;    
    }
}
