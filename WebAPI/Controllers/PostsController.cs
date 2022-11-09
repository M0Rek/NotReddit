using Application.Logic;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]
// [Authorize]
public class PostsController : ControllerBase
{
     private readonly IPostLogic _postLogic;

     public PostsController(IPostLogic postLogic)
     {
          _postLogic = postLogic;
     }
     
     
     [HttpPost]
     public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
     {
          try
          {
               Post post = await _postLogic.CreateAsync(dto);
               //Add validation for user id in post

               return Created($"/posts/{post.Id}", post);
          }
          catch (Exception e)
          {
               Console.WriteLine(e);
               return StatusCode(500, e.Message);
          }
     }
     
     [HttpGet]
     public async Task<ActionResult<Post>> GetAsync()
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
}