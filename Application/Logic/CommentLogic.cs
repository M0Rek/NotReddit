using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
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
        User? user = await _userDao.GetByIdAsync(dto.OriginalPosterId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OriginalPosterId} was not found");
        }

        if (dto.IsParentPost)
        {
            Post? post = await _postDao.GetByIdAsync(dto.CommentedOnId);
            if (post == null)
            {
                throw new Exception($"Post with id {dto.CommentedOnId} was not found");
            }    
        }
        else
        {
            
            Comment? comment = await _commentDao.GetByIdAsync(dto.CommentedOnId);
            if (comment == null)
            {
                throw new Exception($"Comment with id {dto.CommentedOnId} was not found");
            }    
        }
        
        

        ValidateData(dto);
        Comment toCreate = new Comment
        {
            Content = dto.Content,
            OriginalPosterId = dto.OriginalPosterId,
            CommentedOnId = dto.CommentedOnId,
            IsParentPost = dto.IsParentPost,
            
        };

        return await _commentDao.CreateAsync(toCreate);
    }
    
    
    private static void ValidateData(CommentCreationDto commentToCreate)
    {
        if (string.IsNullOrEmpty(commentToCreate.Content))
            throw new ValidationException("Content cannot be null");
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}