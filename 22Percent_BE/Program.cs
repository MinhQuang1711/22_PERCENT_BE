using _22Percent_BE.Data;
using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Extensions;
using _22Percent_BE.Helpers.Jwt;
using _22Percent_BE.Helpers.Mappers;
using _22Percent_BE.Sevices;
using _22Percent_BE.Sevices.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
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
builder.Services.AddControllers().AddJsonOptions(otps=> otps.JsonSerializerOptions.PropertyNamingPolicy=null);
builder.Services.ConfigureCors();
builder.Services.ConfigureMySql(builder);
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.ConfigureJwt();
builder.Services.ConfigureAuthentication(builder); 

//Add scoped
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IServiceManagement, ServiceManagement>();
builder.Services.AddScoped<IRepositoryManagement, RepositoryManagement>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

    
app.UseCors("CrosPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
