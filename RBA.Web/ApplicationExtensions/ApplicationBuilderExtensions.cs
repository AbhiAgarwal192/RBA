using RBA.Middleware;
using Microsoft.AspNetCore.Builder;

namespace RBA.ApplicationExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthorizationMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthenticationMiddleware>();

            return app;
        }
    }
}
