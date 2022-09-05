using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaVenta.Infraestructura.Filters;
using SistemaVenta.Negocio.Extensions;
using SistemaVenta.Negocio.Interfaces;
using SistemaVenta.Negocio.Services;
using System;
using System.Reflection;

namespace SistemaVenta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers(option =>
            {
                option.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(option =>
            {
                option.SuppressModelStateInvalidFilter = true;
            });
            services.AddOptions(Configuration);
            services.AddDbContexts(Configuration);           
            services.AddServices();
            //services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddSwagger(Configuration, Assembly.GetExecutingAssembly().GetName().Name);
            services.AddJWTAuthentication(Configuration);

            services.AddMvc(option =>
            {
                option.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("../swagger/v1/swagger.json", "Sistema de Ventas Api");
            //option.RoutePrefix=string.Empty;
            //https://localhost:44344/swagger/index.html
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
