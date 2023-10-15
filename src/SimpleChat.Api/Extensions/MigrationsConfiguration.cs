using Microsoft.EntityFrameworkCore;
using SimpleChat.Infrastructure.Data;

namespace SimpleChat.Api.Extensions
{
    public static class MigrationsConfiguration
    {
        public static async Task<IApplicationBuilder> RunDbContextMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<ILogger<SimpleChatDbContextSeed>>();

                logger.LogInformation("Database migration running...");

                try
                {
                    var context = serviceProvider.GetRequiredService<SimpleChatDbContext>();
                    context.Database.Migrate();

                    await SimpleChatDbContextSeed.SeedAsyncData(context, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            return app;
        }
    }
}
