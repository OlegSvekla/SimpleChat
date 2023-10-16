using SimpleChat.Api.Extensions;
using SimpleChat.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

LogsConfiguration.Configuration(builder.Configuration, builder.Logging);
DbConfiguration.Configuration(builder.Configuration, builder.Services);
ServicesConfiguration.Configuration(builder.Services);
SwaggerConfiguration.Configuration(builder.Services);

var app = builder.Build();

await app.RunDbContextMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

app.Run();
