using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Application.Posts.Commands.UpdatePost;

public class UpdatePostCommandHandler: IRequestHandler<UpdatePostCommand, Guid>
{
    private readonly IBlogDbContext _dbContext;

    public UpdatePostCommandHandler(IBlogDbContext dbContext)
    {
        _dbContext = dbContext;    
    }  
    
    public async Task<Guid> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}