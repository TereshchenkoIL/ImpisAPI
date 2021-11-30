using Contracts.Interfaces;
using ImpisAPI.Application.Interfaces;
using ImpisAPI.Infrastructure.Photos;
using ImpisAPI.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ImpisApi.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ImpisApi.Web", Version = "v1"});
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("WWW-Authenticate")
                        .WithOrigins("http://localhost:3000");
                });
            });
            
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddSignalR();
            
            return services;
        }
    }
}