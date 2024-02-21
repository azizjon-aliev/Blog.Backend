using Blog.Application.Interfaces;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Posts.Commands.CreatePost;

public class CreatePostCommandHandler: IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IBlogDbContext _dbContext;

    public CreatePostCommandHandler(IBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post { 
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
        };

        await _dbContext.Posts.AddAsync(post, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return post.Id;
    }
}