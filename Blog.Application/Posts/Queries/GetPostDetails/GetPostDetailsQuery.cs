using MediatR;

namespace Blog.Application.Posts.Queries.GetPostDetails;

public class GetPostDetailsQuery: IRequest<PostDetailsVm>
{
    public Guid Id { get; set; }
}