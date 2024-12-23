using CollegeApp.Configuration;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

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
    options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeAppDBConnection"));
});

// Add services to the container.

builder.Services.AddControllers();

//.AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the bearer scheme. Enter Bearer [space] add your token in the text input. Example: Bear asd123",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                },
                Scheme = "oauth2",

                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

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


var KeyJWTSecretforGoogle = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecretforGoogle"));
var KeyJWTSecretforMicrosoft = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecretforMicrosoft"));
var KeyJWTSecretforLocal = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecretforLocal"));

var GoogleAudience = builder.Configuration.GetValue<string>("GoogleAudience");
var MicrosoftAudience = builder.Configuration.GetValue<string>("MicrosoftAudience");
var LocalAudience = builder.Configuration.GetValue<string>("LocalAudience");
var GoogleIssuer = builder.Configuration.GetValue<string>("GoogleIssuer");
var MicrosoftIssuer = builder.Configuration.GetValue<string>("MicrosoftIssuer");
var LocalIssuer = builder.Configuration.GetValue<string>("LocalIssuer");


//JWT Authentication Configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("LoginorGoogleUsers", options =>
{
    //options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(KeyJWTSecretforGoogle),

        ValidateIssuer = true,
        ValidIssuer = GoogleIssuer,

        ValidateAudience = true,
        ValidAudience = GoogleAudience,
    };
}).AddJwtBearer("LoginForMicrosoftUsers", options =>
{
    //options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(KeyJWTSecretforMicrosoft),

        ValidateIssuer = true,
        ValidIssuer = MicrosoftIssuer,

        ValidateAudience = true,
        ValidAudience = MicrosoftAudience,
    };
}).AddJwtBearer("LoginForLocalUsers", options =>
{
    //options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(KeyJWTSecretforLocal),

        ValidateIssuer = true,
        ValidIssuer = LocalIssuer,

        ValidateAudience = true,
        ValidAudience = LocalAudience,
    };
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
