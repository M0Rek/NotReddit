using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class NotRedditContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = NotReddit.db");
    }
    
}