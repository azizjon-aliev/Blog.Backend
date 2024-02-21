using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence;

public class BlogDbContext: DbContext, IBlogDbContext
{
    public DbSet<Post> Posts { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BlogConfiguration());
        base.OnModelCreating(builder);
        
        
    }
}