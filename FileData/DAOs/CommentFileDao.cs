using Application.IDAOs;
using Domain.Models;

namespace FileData.DAOs;

public class CommentFileDao : ICommentDao
{
    private readonly FileContext context;

    public CommentFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Comment> CreateAsync(Comment comment)
    {
        int commentId = 1;
        if (context.Comments.Any())
        {
            commentId = context.Comments.Max(p => p.Id);
            commentId++;
        }

        comment.Id = commentId;
        comment.PublishedDateTime = DateTime.Now;
        context.Comments.Add(comment);
        context.SaveChanges();
        return Task.FromResult(comment);
    }

    public Task<IEnumerable<Comment>> GetByPostIdAsync(int id)
    {
        var existing = context.Comments.Where(c => id == c.CommentedOnId);
        return Task.FromResult(existing);
    }
}