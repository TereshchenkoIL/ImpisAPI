using ImpisAPI.Application.Interfaces;
using ImpisAPI.Application.Mapping;
using ImpisAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImpisAPI.Application.Extensions
{
       public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IReservoirPhotoService, ReservoirPhotoService>();
            services.AddScoped<IReservoirService, ReservoirService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<ISuggestionService, SuggestionService>();
            services.AddScoped<IUserPhotoService, UserPhotoService>();
            services.AddScoped<IWaterParametersService, WaterParametersService>();
            services.AddScoped<IIdealResultService, IdealResultService>();
            services.AddScoped<IIdealWaterParametersService, IdealWaterParametersService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IReservoirTypeService, ReservoirTypeService>();
            
            return services;
        }
    }
}