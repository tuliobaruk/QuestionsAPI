using Microsoft.OpenApi.Models;
using QuestionsAPI.Configurations;
using QuestionsAPI.Services;

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
                          "de referencia para experimentação de estratégias para Cloud Native."
        });
    });

#region [Cors]
builder.Services.AddCors();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
});
#endregion

app.UseAuthorization();
app.MapControllers();
app.Run();