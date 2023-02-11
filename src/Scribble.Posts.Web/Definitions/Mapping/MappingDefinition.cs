using Calabonga.AspNetCore.AppDefinitions;

namespace Scribble.Posts.Web.Definitions.Mapping;

public class MappingDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAutoMapper(typeof(Program));
    }
}