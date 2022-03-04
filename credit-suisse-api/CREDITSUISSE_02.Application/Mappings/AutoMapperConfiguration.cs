using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CREDITSUISSE_02.Application.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new DomainToDtoMappingProfile());
                cfg.AddProfile(new DtoToCommandMappingProfile());
            });
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}