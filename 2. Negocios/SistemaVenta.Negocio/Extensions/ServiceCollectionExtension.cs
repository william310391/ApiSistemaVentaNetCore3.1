using AplicacionPersonal.Infraestructura.Interfaces;
using AplicacionPersonal.Infraestructura.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SistemaVenta.Core.CustionEntities;
using SistemaVenta.Infraestructura.Data;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Infraestructura.Repositories;
using SistemaVenta.Infrestructuras.Options;
using System.Text;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using SistemaVenta.Negocio.Interfaces;
using SistemaVenta.Negocio.Services;

namespace SistemaVenta.Negocio.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VentasContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CNSQL"));
            });
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
            //services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            //return services;
        }


        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddSingleton<IUrlService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var requet = accesor.HttpContext.Request;
                var absoluteUrl = string.Concat(requet.Scheme, "://", requet.Host.ToUriComponent());
                return new UrlService(absoluteUrl);
            });
        }

        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });
        }

        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Venta", Version = "v1" });
                var xmlFile = $"{xmlFileName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);

                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
        }

    }
}
