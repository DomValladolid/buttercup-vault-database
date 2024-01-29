using Microsoft.EntityFrameworkCore;
using ButtercupAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserDataContext>(opt =>
    opt.UseSqlite(Environment.GetEnvironmentVariable("LocalDbConnectionString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope()) 
{
    var dataContext = scope.ServiceProvider.GetRequiredService<UserDataContext>();
    dataContext.Database.EnsureCreated();
}

app.Run();
