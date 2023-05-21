using Newtonsoft.Json;

namespace Lab4.Input;

internal sealed class EndPointInputStrategy : IInputStrategy
{
    private readonly string _requestUrl;
    private readonly HttpClient _httpClient;

    public EndPointInputStrategy(string baseUrl, string requestUrl)
    {
        _requestUrl = requestUrl;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),
        };
    }

    public async Task<T[]?> GetData<T>()
    {
        using HttpResponseMessage response = await _httpClient.GetAsync(_requestUrl);

        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        try
        {
            T[]? models = JsonConvert.DeserializeObject<T[]>(json);
            return models;
        }
        catch (Exception)
        {
            return Array.Empty<T>();
        }
    }
}