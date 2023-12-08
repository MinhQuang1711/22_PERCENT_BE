using _22Percent_BE.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace _22Percent_BE.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options=>
            {
                options.AddPolicy("CrosPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureMySql(this IServiceCollection services, WebApplicationBuilder builder)
        {
            string connectString = builder.Configuration.GetConnectionString("Database");
            services.AddDbContext<_22Context>
            (
                options => options.UseMySql
                (
                    connectString,
                    ServerVersion.AutoDetect(connectString),
                    options =>
                    {
                        options.EnableStringComparisonTranslations();
                    }
                )
            );
        }

        public static void ConfigureJwt(this IServiceCollection services)
        {
            services.AddSwaggerGen(otps =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                };
                otps.AddSecurityDefinition("Bearer", securityScheme);
                otps.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new string[] { } }
                });

            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, WebApplicationBuilder builder) 
        {
            services.AddAuthentication(otps =>
            {
                otps.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                otps.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(otps =>
            {
                otps.SaveToken = true;
                otps.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Issuer"],
                    ValidAudience = builder.Configuration["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["SecretKey"])),
                };
            });
        }
    }
}
