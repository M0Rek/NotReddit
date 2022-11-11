using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CommentsController : ControllerBase
{
    private readonly ICommentLogic _commentLogic;
    private readonly IAuthLogic _authLogic;

    public CommentsController(ICommentLogic commentLogic, IAuthLogic authLogic)
    {
        _commentLogic = commentLogic;
        _authLogic = authLogic;
    }


    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync(CommentCreationRequestDto dto)
    {
        try
        {
            var  userId= User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

            var originalPoster = await _authLogic.GetByIdAsync(Int32.Parse(userId ?? throw new InvalidOperationException()));

            
            Comment comment = await _commentLogic.CreateAsync(new CommentCreationDto(originalPoster,dto.CommentedOnId,dto.Content));
            return Created($"/comments/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{postId:int}") , AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Post>>> GetByPostIdAsync(int postId)
    {
        try
        {
            var comments = await _commentLogic.GetByPostIdAsync(postId);

            return Ok(comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}