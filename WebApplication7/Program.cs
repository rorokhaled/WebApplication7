using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Appdbcontext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddScoped<Imovie, repomovie>();
builder.Services.AddScoped<Iceinma, repocin>();

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
