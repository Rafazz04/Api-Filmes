using ApiFilmes.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiFilmes.Mapper;
using ApiFilmes.Service;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("DataContext"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
