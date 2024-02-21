using AutoMapper;
using Blog.Domain;

namespace Blog.Application.Posts.Queries.GetPostList;

public class PostLookupDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Post, PostLookupDto>()
            .ForMember(postDto => postDto.Id, opt => opt.MapFrom(post => post.Id))
            .ForMember(postDto => postDto.Title, opt => opt.MapFrom(post => post.Title))
            .ForMember(postDto => postDto.Description, opt => opt.MapFrom(post => post.Description));
    }
}