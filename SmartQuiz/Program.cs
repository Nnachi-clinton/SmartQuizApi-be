using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using SmartQuiz.Application.ServicesImplementation;

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
