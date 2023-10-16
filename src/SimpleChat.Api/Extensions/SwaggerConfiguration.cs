using Microsoft.OpenApi.Models;
using System.Reflection;

namespace SimpleChat.Api.Extensions
{
    public static class SwaggerConfiguration
    {
        public static void Configuration(
            IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SimpleChat.Api",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                _.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                _.EnableAnnotations();
            });
        }
    }
}
