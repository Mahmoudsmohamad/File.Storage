using Microsoft.OpenApi.Models;
using Youxel.FileStorage.Domain.Interfaces;
using Youxel.FileStorage.Infrastrucure.Interfaces;
using Youxel.FileStorage.Infrastrucure.Repositories;
using Youxel.FileStorage.Infrastrucure.Services;
using Youxel.FileStorge.API;
using Youxel.FileStorge.Application.Interfaces;
using Youxel.FileStorge.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IFileRepository, FileRepository>();
builder.Services.AddSingleton<IStorageClient, StorageClient>();

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
