using AutoMapper;
using Blog.Application.Common.Exceptions;
using Blog.Application.Interfaces;
using Blog.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Queries.GetPostDetails;

public class GetPostDetailsQueryHandler: IRequestHandler<GetPostDetailsQuery, PostDetailsVm>
{
    private readonly IBlogDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPostDetailsQueryHandler(IBlogDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PostDetailsVm> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Posts.FirstOrDefaultAsync(post => post.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        return _mapper.Map<PostDetailsVm>(entity);
    }
}