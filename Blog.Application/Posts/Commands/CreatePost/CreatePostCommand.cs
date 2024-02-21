using MediatR;

namespace Blog.Application.Posts.Commands.CreatePost;

public class CreatePostCommand: IRequest<Guid>
{
    public string Title { get; set; }
    public string? Description { get; set; }
}