using System.Net.Http.Json;
using System.Text.Json.Serialization;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Services;

public class PersonService
{
    private readonly HttpClient _httpClient;

    public PersonService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users?page=1");
        return response?.Data ?? new List<Person>();
    }

    private class ApiResponse
    {
        [JsonPropertyName("data")]
        public List<Person> Data { get; set; } = new();
    }
}