using AutoMapper;
using Scribble.Blog.Models;
using Scribble.Blog.Web.Models;

namespace Scribble.Blog.Web.Features.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogEntity, BlogEntityViewModel>();
        
        CreateMap<BlogEntityCreateViewModel, BlogEntity>()
            .ForMember(x => x.Id, i => i.Ignore())
            .ForMember(x => x.Title, i => i.MapFrom(m => m.Title))
            .ForMember(x => x.Content, i => i.MapFrom(m => m.Content));
        
        CreateMap<BlogEntityUpdateViewModel, BlogEntity>()
            .ForMember(x => x.Id, i => i.Ignore())
            .ForMember(x => x.Title, i => i.MapFrom(m => m.Title))
            .ForMember(x => x.Content, i => i.MapFrom(m => m.Content));
    }
}