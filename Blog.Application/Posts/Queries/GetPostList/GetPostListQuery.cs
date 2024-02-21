using MediatR;

namespace Blog.Application.Posts.Queries.GetPostList;

public class GetPostListQuery: IRequest<PostListVm>
{
    public string Title { get; set; }
}