using CollegeApp.Configuration;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.MyLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    //.MinimumLevel.Information()
    .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

builder.Logging.AddSerilog();

// Logging into debug window only
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddDbContext<CollegeDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeAppDBConnectionOffice"));
});

// Add services to the container.

builder.Services.AddControllers();

//.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add auto mapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// https://www.youtube.com/watch?v=Pb2VZWoHSnA&ab_channel=PatrickGod
builder.Services.AddScoped<IMyLogger, LogToFile>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped(typeof(ICollegeRepository<>), typeof(CollegeRepository<>));
builder.Services.AddCors(options => {

    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
    //options.AddPolicy("AllowAll", policy =>
    //{
    //    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    //});
    options.AddPolicy("AllowOnlyLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().WithHeaders("Accept").WithMethods("GET", "");
    });

    options.AddPolicy("AllowOnlyGoogle", policy =>
    {
        policy.WithOrigins("http://google.com;http://gmail.com;http://drive.google.com").AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("AllowOnlyMicrosoft", policy =>
    {
        policy.WithOrigins("http://outlook.com;http://microsoft.com;http://onedrive.com").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// use before UseAuthorization and after Routing
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
