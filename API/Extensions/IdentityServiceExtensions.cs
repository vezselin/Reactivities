using Domain;
using Persistence;

namespace API.Extensions;

public static class IdentityServiceExtensions 
{ 
    public static IServiceCollection AddIdentityServicees(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>();

        services.AddAuthentication();

        return services;
    }
}