using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using MediatR;

namespace Blog.Application.Posts.Commands.DeletePost;

public class DeletePostCommandHandler: IRequestHandler<DeletePostCommand>
{
    private readonly IBlogDbContext _dbContext;

    public DeletePostCommandHandler(IBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        _dbContext.Posts.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}