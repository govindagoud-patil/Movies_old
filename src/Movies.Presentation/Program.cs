using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using Movies.Application;
using Movies.Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddMovieEndpoints();

app.Run();
