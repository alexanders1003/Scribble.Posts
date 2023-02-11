using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OpenIddict.Validation.AspNetCore;

namespace Scribble.Posts.Web.Definitions.Identity;

public static class AuthenticationData
{
    public const string AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
}