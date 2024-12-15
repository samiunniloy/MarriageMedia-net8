using API.DataAccessLayer;
using API.Models;
using API.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Configuration;
using System.Runtime.Serialization.DataContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//builder.Services.AddSingleton<IMongoClient>(sp =>
//{
//    var connectionString = builder.Configuration["DatabaseSettings:ConnectionString"];
//    return new MongoClient(connectionString);
//});

//builder.Services.AddScoped(sp =>
//{
//    var mongoClient = sp.GetRequiredService<IMongoClient>();
//    var databaseName = builder.Configuration["DatabaseSettings:DatabaseName"];
//    return mongoClient.GetDatabase(databaseName);
//});
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.BuildServiceProvider();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(x =>
{
x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200");
});
app.MapControllers();

app.Run();
