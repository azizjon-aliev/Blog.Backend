using MediatR;

namespace Blog.Application.Posts.Commands.UpdatePost;

public class UpdatePostCommand: IRequest<Guid>
{
    public Guid Id { get; set;  }
    public string Title { get; set; }
    public string? Description { get; set; }
}