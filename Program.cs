using Microsoft.OpenApi.Models;
using PBIC_CloudNative.Configurations;
using PBIC_CloudNative.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(key: "MongoDataBase"));
builder.Services.AddSingleton<QuestionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
       c =>
       {
           c.EnableAnnotations();
           c.SwaggerDoc("v1", new OpenApiInfo
           {
               Title = "Docs Web API PBIC",
               Description = "API criada como parte do desenvolvimento de uma aplicação " +
               "de referência para experimentação de estratégias para Cloud Native."
           });
       });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
app.UseHttpsRedirection();
*/

app.UseAuthorization();

app.MapControllers();

app.Run();
