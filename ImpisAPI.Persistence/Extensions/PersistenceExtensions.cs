using ImpisAPI.Domain.Repositories;
using ImpisAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImpisAPI.Persistence.Extensions
{
       public static class PersistenceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReservoirRepository, ReservoirRepository>();
            services.AddScoped<ISuggestionRepository, SuggestionRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUserPhotoRepository, UserPhotoRepository>();
            services.AddScoped<IReservoirPhotoRepository, ReservoirPhotoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWaterParametersRepository, WaterParametersRepository>();
            return services;
        }
    }
}