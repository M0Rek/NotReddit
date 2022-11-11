using System.ComponentModel.DataAnnotations;
using Application.IDAOs;
using Application.ILogic;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly IUserDao _userDao;
    private readonly IPostDao _postDao;
    private readonly ICommentDao _commentDao;

    public CommentLogic(IUserDao userDao, IPostDao postDao, ICommentDao commentDao)
    {
        _userDao = userDao;
        _postDao = postDao;
        _commentDao = commentDao;
    }


    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    {
        User? user = await _userDao.GetByIdAsync(dto.OriginalPoster.Id);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OriginalPoster.Id} was not found");
        }

        //TODO Implements comments to comments
        // if (dto.IsParentPost)
        // {
        Post? post = await _postDao.GetByIdAsync(dto.CommentedOnId);
        if (post == null)
        {
            throw new Exception($"Post with id {dto.CommentedOnId} was not found");
        }
        // }
        // else
        // {
        //     Comment? comment = await _commentDao.GetByIdAsync(dto.CommentedOnId);
        //     if (comment == null)
        //     {
        //         throw new Exception($"Comment with id {dto.CommentedOnId} was not found");
        //     }    
        // }


        ValidateData(dto);
        Comment toCreate = new Comment
        {
            Content = dto.Content,
            OriginalPoster = dto.OriginalPoster,
            CommentedOnId = dto.CommentedOnId,
        };

        return await _commentDao.CreateAsync(toCreate);
    }


    private static void ValidateData(CommentCreationDto commentToCreate)
    {
        if (string.IsNullOrEmpty(commentToCreate.Content))
            throw new ValidationException("Content cannot be null");
    }

    public Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        return _commentDao.GetByPostIdAsync(id);
    }
}