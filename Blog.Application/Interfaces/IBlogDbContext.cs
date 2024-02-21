using Blog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces;

public interface IBlogDbContext
{
    DbSet<Post> Posts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}