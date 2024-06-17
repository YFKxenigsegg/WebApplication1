using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Configurations;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<Settings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("Settings:ConnectionString")));
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped(sp =>sp.GetRequiredService<IMongoClient>().GetDatabase(builder.Configuration.GetValue<string>("Settings:DatabaseName")));
builder.Services.AddScoped(sp => sp.GetRequiredService<IMongoDatabase>().GetCollection<Form>(builder.Configuration.GetValue<string>("Settings:CollectionName")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
