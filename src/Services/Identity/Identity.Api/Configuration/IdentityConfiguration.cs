using Identity.Api.Configuration.Identity;
using IdentityServer4.Models;

namespace Identity.Api.Configuration;

public static class IdentityConfiguration
{
    public static WebApplicationBuilder ConfigureIdentity(this WebApplicationBuilder app)
    {
        ConfigureIdentityServer(app);
        return app;
    }

    private static void ConfigureIdentityServer(WebApplicationBuilder app)
    {
        app.Services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiScopes(IdentityAuthConfig.ApiScopes)
            .AddInMemoryClients(IdentityAuthConfig.Clients);
        
    }
}