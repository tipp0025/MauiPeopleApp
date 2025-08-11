using System.Text.Json.Serialization;

namespace MauiPeopleApp.Models;

public class Person
{
    public int Id { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("first_name")]
    public required string First_Name { get; set; }

    [JsonPropertyName("last_name")]
    public required string Last_Name { get; set; }

    [JsonPropertyName("avatar")]
    public required string Avatar { get; set; }

    public string FullName => $"{First_Name} {Last_Name}";
}