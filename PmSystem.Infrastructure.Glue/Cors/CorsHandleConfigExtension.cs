using Microsoft.Extensions.DependencyInjection;

namespace PmSystem.Infrastructure.Glue.Cors
{
    public static class CorsHandleConfigExtension
    {
        public static void Configure(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}
