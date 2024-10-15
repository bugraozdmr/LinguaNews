using LinguaNews.Api;
using LinguaNews.Application;
using LinguaNews.Infrastructure;
using LinguaNews.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


// Add Services to the container

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    // carefull -- nasıl oldu bilmiyorum application Dependency Injection eklerken WebApplicationu tanımaya başladı dotnet clean
    // dotnet build denersin
    await app.InitializeDatabaseAsync();
}

app.Run();