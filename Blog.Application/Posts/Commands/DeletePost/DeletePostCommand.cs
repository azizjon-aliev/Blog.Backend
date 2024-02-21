using MediatR;

namespace Blog.Application.Posts.Commands.DeletePost;

public class DeletePostCommand: IRequest
{
    public Guid Id { get; set; }
}