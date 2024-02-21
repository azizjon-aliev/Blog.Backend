using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Queries.GetPostList;

public class GetPostListQueryHandler: IRequestHandler<GetPostListQuery, PostListVm>
{
    private readonly IBlogDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPostListQueryHandler(IBlogDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PostListVm> Handle(GetPostListQuery request, CancellationToken cancellationToken)
    {
        var postsQuery = await _dbContext.Posts.Where(post => post.Title == request.Title)
            .ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PostListVm { Posts = postsQuery };
    }
}