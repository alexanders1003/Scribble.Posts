using AutoMapper;
using Scribble.Posts.Models;
using Scribble.Posts.Web.Models;

namespace Scribble.Posts.Web.Definitions.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PostEntity, PostEntityViewModel>();
    }
}
