using _22Percent_BE.Data;
using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Helpers.Mappers;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions
    (
        otps => otps.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    ); ;
        

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryManagement, RepositoryManagement>();
builder.Services.AddScoped<IServiceManagement, ServiceManagement>();
builder.Services.AddControllers().AddJsonOptions(otps=> otps.JsonSerializerOptions.PropertyNamingPolicy=null);
string _connectString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<_22Context>
    (
        options => options.UseMySql
        (
            _connectString, 
            ServerVersion.AutoDetect(_connectString),
            options => 
            {
                options.EnableStringComparisonTranslations();
            }
        )
    );

builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddAuthentication(otps =>
{
    otps.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    otps.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(otps =>
{

//      "SecretKey": "your_secret_key_here",
//      "Issuer": "your_issuer_here",
//      "Audience": "your_audience_here",
    otps.SaveToken = true;
    otps.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
    };
});


//Add scoped
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

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
