using AutoMapper;
using Blog.Application.Common.Mappings;
using Blog.Domain;

namespace Blog.Application.Posts.Queries.GetPostDetails;

public class PostDetailsVm: IMapWith<Post>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Post, PostDetailsVm>()
            .ForMember(postVm => postVm.Id, opt => opt.MapFrom(post => post.Id))
            .ForMember(postVm => postVm.Title, opt => opt.MapFrom(post => post.Title))
            .ForMember(postVm => postVm.Description, opt => opt.MapFrom(post => post.Description));
    }
}