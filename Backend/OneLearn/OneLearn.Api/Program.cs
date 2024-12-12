using Microsoft.EntityFrameworkCore;
using OneLearn.Application;
using OneLearn.Infrastructure;
using OneLearn.Infrastructure.Common.DBContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAppplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connection = builder.Configuration.GetConnectionString("Redis");
    redisOptions.Configuration = connection;
});

// Add CORS services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() // Allow requests from any origin
                   .AllowAnyHeader() // Allow all headers
                   .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, PUT, etc.)
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionWork"));
});

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
