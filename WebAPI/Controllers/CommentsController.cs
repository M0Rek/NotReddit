using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
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
            //Add validation for user id in post

            return Created($"/comments/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}