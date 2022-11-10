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


    public CommentsController(ICommentLogic commentLogic)
    {
        _commentLogic = commentLogic;
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync(CommentCreationDto dto)
    {
        try
        {
            Comment comment = await _commentLogic.CreateAsync(dto);
            return Created($"/comments/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{id:int}") , AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Post>>> GetByPostIdAsync(int id)
    {
        try
        {
            var comments = await _commentLogic.GetByPostIdAsync(id);

            return Ok(comments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}