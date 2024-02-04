using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using Movies.Application;
using Movies.Presentation;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});
builder.Services.AddCors(opt => {

    opt.AddPolicy("AllowReactApp", opt => {
        opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();// WithOrigins("http://localhost:5173");
    });
    
    });
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.AddMovieEndpoints();

app.Run();
