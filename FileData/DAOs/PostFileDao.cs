using Application.DaoInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;
        post.PublishedDateTime = DateTime.Now;
        context.Posts.Add(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();

        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(p => id == p.Id);

        return Task.FromResult(existing);
    }
}