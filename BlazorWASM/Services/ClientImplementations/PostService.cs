using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using IPostService = BlazorWASM.Services.ClientInterfaces.IPostService;

namespace BlazorWASM.Services.ClientImplementations;

public class PostService : IPostService
{
    private readonly System.Net.Http.HttpClient _client;

    public PostService(System.Net.Http.HttpClient client)
    {
        _client = client;
    }

    public async Task<Post> CreateAsync(PostCreationRequestDto dto)
    {
        string postAsJson = JsonSerializer.Serialize(dto);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Jwt);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync("/Posts", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        var created = JsonSerializer.Deserialize<Post>(responseContent)!;

        return created;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        var response = await _client.GetAsync("Posts");

        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Exception thrown here");
            throw new Exception(result);
        }

        var created = JsonSerializer.Deserialize<List<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }


    public async Task<Post?> GetByIdAsync(int id)
    {
        var response = await _client.GetAsync($"Posts/{id}");

        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        var created = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }
}