using Application.IDAOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly NotRedditContext _context;

    public CommentEfcDao(NotRedditContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        comment.PublishedDateTime = DateTime.Now;
        
        EntityEntry<Comment> newComment = await _context.Comments.AddAsync(comment);
        
        await _context.SaveChangesAsync();
        return newComment.Entity;
    }

    public async Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        return await _context.Comments.Where(comment => comment.CommentedOn.Id == id).Include(comment => comment.OriginalPoster).ToListAsync();
    }
}