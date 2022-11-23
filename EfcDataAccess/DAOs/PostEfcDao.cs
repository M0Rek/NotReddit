using Application.IDAOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly NotRedditContext _context;

    public PostEfcDao(NotRedditContext context)
    {
        _context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        post.PublishedDateTime = DateTime.Now;

        EntityEntry<Post> newPost = await _context.Posts.AddAsync(post);

        await _context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _context.Posts.Include(post => post.OriginalPoster).FirstOrDefaultAsync(post => post.Id == id);
    }
}