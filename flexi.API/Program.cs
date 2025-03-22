using TechTalk.DatabaseAccessor.Models;
using TechTalk.DatabaseAccessor.Services;
using flexi.Logic;
using flexi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
  .Build();

var configuration = builder.Configuration;

// Add services to the container.
var databaseCredentials = configuration.GetSection(nameof(DatabaseCredential)).Get<DatabaseCredential>();
databaseCredentials!.Validate();
builder.Services.AddSingleton(databaseCredentials);
builder.Services.AddSingleton<IDatabaseAccessor, MySqlDatabaseAccessor>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IStudentLogic, StudentLogic>();

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
