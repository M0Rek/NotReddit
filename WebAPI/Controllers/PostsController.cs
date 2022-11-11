using System.Security.Claims;
using System.Text.Json;
using Application.ILogic;
using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PostsController : ControllerBase
{
    private readonly IPostLogic _postLogic;
    private readonly IAuthLogic _authLogic;

    public PostsController(IPostLogic postLogic, IAuthLogic authLogic)
    {
        _postLogic = postLogic;
        _authLogic = authLogic;
    }


    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationRequestDto dto)
    {
        try
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            var originalPoster =
                await _authLogic.GetByIdAsync(Int32.Parse(userId ?? throw new InvalidOperationException()));

            Post post = await _postLogic.CreateAsync(new PostCreationDto()
            {
                OriginalPoster = originalPoster,
                Title = dto.Title,
                Content = dto.Content
            });
            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync()
    {
        try
        {
            IEnumerable<Post> posts = await _postLogic.GetAsync();

            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}"), AllowAnonymous]
    public async Task<ActionResult<Post>> GetByIdAsync(int id)
    {
        try
        {
            Post? posts = await _postLogic.GetByIdAsync(id);

            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}