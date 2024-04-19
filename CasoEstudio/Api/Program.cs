using Application;
using Infrastructure;
using Persistence;
using System.Text.Json.Serialization;

const string LOCAL_HOST_CORS = "Web";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LOCAL_HOST_CORS, policy =>
    {
        policy.WithOrigins("http://localhost:8001", "https://localhost:44301")
            .WithHeaders("*")
            .WithMethods("*");
    });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(LOCAL_HOST_CORS);

app.UseAuthorization();

app.MapControllers();

app.Run();
