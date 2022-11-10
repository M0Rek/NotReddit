using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorWASM.Services.ClientInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace BlazorWASM.Services.ClientImplementations;

public class CommentService : ICommentService
{
    private readonly HttpClient _client;

    public CommentService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Comment> CreateAsync(CommentCreationRequestDto dto)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Jwt);
        var result = await _client.PostAsJsonAsync("Comments", dto);

        string responseContent = await result.Content.ReadAsStringAsync();
        if (!result.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }

        var created = JsonSerializer.Deserialize<Comment>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return created;
    }

    public async Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        var response = await _client.GetAsync($"Comments/{id}");

        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        var created = JsonSerializer.Deserialize<IEnumerable<Comment>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return created;
    }
}