using SmartQuiz.Configurations;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using SmartQuiz.Persistence.Extensions;
using SmartQuiz.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(provider =>
{
    var cloudinarySettings = provider.GetRequiredService<IOptions<CloudinarySetting>>().Value;

    Account cloudinaryAccount = new(
        cloudinarySettings.CloudName,
        cloudinarySettings.APIKey,
        cloudinarySettings.APISecret);
    return new Cloudinary(cloudinaryAccount);
});

// Add services to the container.

var configuration = builder.Configuration;
//var services = builder.Services;
//var env = builder.Environment;

// Add services to the container.
builder.Services.AddDependencies(configuration);
builder.Services.AddAuthentication();
builder.Services.AuthenticationConfiguration(configuration);

// Identity  configuration
builder.Services.AddLoggingConfiguration(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
