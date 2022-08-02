using IdentityServer.Auth;
using IdentityServer.Data.Repositories;
using IdentityServer.Services.Profile;
using IdentityServer.Services.User.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Extensions;

public static class IdentityServer
{
    public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
    {
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.AddProfileService<CustomProfileService>();
        builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

        return builder;
    }
}
