using Microsoft.EntityFrameworkCore;
using Vissoft.Core.Interfaces;
using Vissoft.Infrastracture.Data;
using Vissoft.Infrastracture.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("vissoftDb");
builder.Services.AddDbContext<VissoftDbContext>(option => option.UseMySql(connectionString, ServerVersion.Parse("8.0.31-mysql")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddSwaggerGen();
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
