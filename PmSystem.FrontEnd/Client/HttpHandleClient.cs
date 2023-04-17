using System.Text;
using Newtonsoft.Json;

public class HttpHandleClient<T>
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;

    public HttpHandleClient(string apiBaseUrl)
    {
        _httpClient = new HttpClient();
        _apiBaseUrl = apiBaseUrl;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}{endpoint}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
    }

    public async Task<T> GetByIdAsync(string endppoint, int id)
    {
        var response = await _httpClient.GetAsync($"{_apiBaseUrl}{endppoint}/{id}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }

    public async Task CreateAsync(string endpoint, T item)
    {
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiBaseUrl}{endpoint}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(string endpoint, int id, T item)
    {
        var json = JsonConvert.SerializeObject(item);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_apiBaseUrl}{endpoint}/{id}", content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(string endpoint, int id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}{endpoint}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
