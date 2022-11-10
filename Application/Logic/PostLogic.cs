using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IUserDao _userDao;
    private readonly IPostDao _postDao;

    public PostLogic(IUserDao userDao, IPostDao postDao)
    {
        _userDao = userDao;
        _postDao = postDao;
    }


    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await _userDao.GetByIdAsync(dto.OriginalPoster.Id);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OriginalPoster.Id} was not found");
        }

        ValidateData(dto);
        Post toCreate = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            OriginalPoster = dto.OriginalPoster,
        };

       return await _postDao.CreateAsync(toCreate);
    }
    
    private static void ValidateData(PostCreationDto postToCreate)
    {
        
        if (string.IsNullOrEmpty(postToCreate.Title))
            throw new ValidationException("Title cannot be null");

        if (string.IsNullOrEmpty(postToCreate.Content))
            throw new ValidationException("Content cannot be null");
    }


    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await _postDao.GetAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _postDao.GetByIdAsync(id);
    }
}